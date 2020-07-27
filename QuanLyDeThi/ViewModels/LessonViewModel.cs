using QuanLyDeThi.Models;
using QuanLyDeThi.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLyDeThi.ViewModels
{
    public class LessonViewModel : BaseViewModel
    {

        private ObservableCollection<Lesson> _lstLesson;
        public ObservableCollection<Lesson> LstLesson
        {
            get => _lstLesson;
            set
            {
                _lstLesson = value;
                OnPropertyChanged();
            }
        }

        private List<Lesson> tempLesson;

        private Lesson _SelectedItem;
        public Lesson SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _Search;
        public string Search
        {
            get => _Search;
            set
            {
                if (_Search != value)
                {
                    _Search = value;
                    OnPropertyChanged();
                    Console.WriteLine("_Search : " + _Search);
                    OnSearch(value);
                }
            }
        }

        private void OnSearch(string str)
        {
            if (LstLesson != null)
            {
                var lstTemp = (from p in tempLesson
                               where p.Id.ToString().IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0
                               || p.LessonName.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0
                               select p).ToList();

                if (lstTemp != null)
                {
                    LstLesson = new ObservableCollection<Lesson>(lstTemp);
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public LessonViewModel()
        {
            LstLesson = new ObservableCollection<Lesson>(DataProvider.Instance.DB.Lessons);
            tempLesson = LstLesson.ToList();
            AddCommand = new RelayCommand<object>((p) => { return true; }, OnAddLesson);
            EditCommand = new RelayCommand<object>((p) => { return true; }, OnEditLesson);
            DeleteCommand = new RelayCommand<object>((p) => { return true; }, OnDeleteLesson);
        }
        private void OnAddLesson(object sender)
        {
            QuestionWindow questionCommand = new QuestionWindow();
            var questionVM = questionCommand.DataContext as QuestionViewModel;
            questionVM.LessonItem = null;
            questionVM.LoadQuestion();
            questionVM.commandType = CommandType.INSERT;
            questionVM.meWindow = questionCommand;
            questionVM.OnLessonDone += OnLessonChangedDone;
            questionCommand.ShowDialog();
        }
        private void OnEditLesson(object sender)
        {
            QuestionWindow questionCommand = new QuestionWindow();
            var questionVM = questionCommand.DataContext as QuestionViewModel;
            questionVM.LessonItem = SelectedItem;
            questionVM.LoadQuestion();
            questionVM.commandType = CommandType.UPDATE;
            questionVM.meWindow = questionCommand;
            questionVM.OnLessonDone += OnLessonChangedDone;
            questionCommand.ShowDialog();
        }

        private void OnDeleteLesson(object sender)
        {
            if (SelectedItem != null)
            {
                DataProvider.Instance.DB.Lessons.Remove(SelectedItem);
                DataProvider.Instance.DB.SaveChanges();

                if (LstLesson.Contains(SelectedItem))
                    LstLesson.Remove(SelectedItem);
            }
        }
        private void OnLessonChangedDone(Lesson data)
        {
            var item = LstLesson.Where(x => x.Id == data.Id).FirstOrDefault();

            if (item != null)
            {
                var index = LstLesson.IndexOf(item);
                LstLesson.RemoveAt(index);
                LstLesson.Insert(index, data);
                return;
            }
            LstLesson.Add(data);
        }
    }
}
