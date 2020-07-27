using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QuanLyDeThi.Models;
using QuanLyDeThi.Utils;
using QuanLyDeThi.Views;

namespace QuanLyDeThi.ViewModels
{
    public class QuestionViewModel : BaseViewModel
    {
        public CommandType commandType = CommandType.INSERT;
        public int LessonId { get; set; }
        public Window meWindow;
        public delegate void OnInsertOrUpdateLessonSucces(Lesson data);
        public event OnInsertOrUpdateLessonSucces OnLessonDone;
        private ObservableCollection<Question> _lstQuestion;
        public ObservableCollection<Question> LstQuestion {
            get => _lstQuestion;
            set {
                _lstQuestion = value;
                OnPropertyChanged();
            }
        }

        private List<Question> tempQuestion;

        private Lesson _LessonItem;
        public Lesson LessonItem
        {
            get => _LessonItem;
            set
            {
                _LessonItem = value;
                OnPropertyChanged();
                Search = "";
                if (_LessonItem != null)
                {
                    Title = _LessonItem.LessonName;
                    AnswerTime = _LessonItem.AnswerTime;
                }
                else
                {
                    Title = "";
                    AnswerTime = null;
                }
            }
        }


        private Question _SelectedItem;
        public Question SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        private int? _AnswerTime;
        public int? AnswerTime
        {
            get => _AnswerTime;
            set
            {

                _AnswerTime = value;
                OnPropertyChanged();
            }
        }

        private string _Search;
        public string Search
        {
            get => _Search;
            set
            {
                if(_Search != value)
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
            if(LstQuestion != null)
            {
                var lstTemp = (from p in tempQuestion
                               where p.Id.ToString().IndexOf(str,StringComparison.OrdinalIgnoreCase) >= 0
                               || p.QuestionTitle.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0
                               select p ).ToList();

                if(lstTemp != null)
                {
                    LstQuestion = new ObservableCollection<Question>(lstTemp);
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CompleteCommand { get; set; }

        public QuestionViewModel()
        {
           
            AddCommand = new RelayCommand<object>((p) => {  return true; }, OnAddQuestion); 
            EditCommand = new RelayCommand<object>((p) => { return true; }, OnEditQuestion);
            DeleteCommand = new RelayCommand<object>((p) => { return true; }, OnDeleteQuestion);
            CompleteCommand = new RelayCommand<object>((p) => { return true; }, OnCompleteQuestion);
        }

        public void LoadQuestion()
        {
            if (LessonItem != null)
            {
                LstQuestion = new ObservableCollection<Question>(DataProvider.Instance.DB.Questions.Where(x => x.LessonId == LessonItem.Id).ToList());
            }
            else
            {
                Console.WriteLine(LessonItem == null);
                LstQuestion = new ObservableCollection<Question>();
            }

            tempQuestion = LstQuestion.ToList();
        }

        private void OnAddQuestion(object sender)
        {
            QuestionCommandWindow deThiCommand = new QuestionCommandWindow();
            var dethiVM = deThiCommand.DataContext as QuestionCommandViewModel;
            dethiVM.SelectedItem = null;
            if (commandType == CommandType.UPDATE)
                dethiVM.LessonId = LessonItem.Id;
            dethiVM.StrButton = "Thêm";
            dethiVM.meWindow = deThiCommand;
            dethiVM.commandType = commandType;
            dethiVM.OnQuestionDone += OnQuestionDone;
            deThiCommand.ShowDialog();
            dethiVM.OnQuestionDone -= OnQuestionDone;
        }

        

        private void OnEditQuestion(object sender)
        {
            QuestionCommandWindow deThiCommand = new QuestionCommandWindow();
            var dethiVM = deThiCommand.DataContext as QuestionCommandViewModel;
            dethiVM.SelectedItem = SelectedItem;
            dethiVM.StrButton = "Cập nhật";
            dethiVM.meWindow = deThiCommand;
            dethiVM.commandType = commandType;
            dethiVM.OnQuestionDone += OnQuestionDone;
            deThiCommand.ShowDialog();
            dethiVM.OnQuestionDone -= OnQuestionDone;
        }

        private void OnDeleteQuestion(object sender)
        {
            if(SelectedItem != null)
            {
                DataProvider.Instance.DB.Questions.Remove(SelectedItem);
                DataProvider.Instance.DB.SaveChanges();
                if (LstQuestion.Contains(SelectedItem))
                    LstQuestion.Remove(SelectedItem);
            }
        }
        private void OnCompleteQuestion(object sender)
        {
            if(commandType == CommandType.INSERT)
            {
                var ItemLesson = new Lesson();
                ItemLesson.UserCreatedId = AppDataConfig.Instance.userData.Id;
                ItemLesson.CreateDate = DateTime.Now;
                ItemLesson.AnswerTime = AnswerTime;
                ItemLesson.LessonName = Title;
                ItemLesson.ModifyDate = DateTime.Now;
                DataProvider.Instance.DB.Lessons.Add(ItemLesson);
                DataProvider.Instance.DB.SaveChanges();
                int LessonId = ItemLesson.Id;
                for(int i = 0; i < LstQuestion.Count; i++)
                {
                    LstQuestion[i].LessonId = LessonId;
                }
                DataProvider.Instance.DB.Questions.AddRange(LstQuestion);
                DataProvider.Instance.DB.SaveChanges();

                if (meWindow != null)
                    meWindow.Close();
                if (OnLessonDone != null)
                    OnLessonDone(ItemLesson);

            }
            else if(commandType == CommandType.UPDATE)
            {
                var Item = DataProvider.Instance.DB.Lessons.Where(x => x.Id == LessonItem.Id).FirstOrDefault();
                if(Item != null)
                {
                    Item.LessonName = Title;
                    Item.ModifyDate = DateTime.Now;
                    Item.AnswerTime = AnswerTime;
                    DataProvider.Instance.DB.SaveChanges();
                }

                if (meWindow != null)
                    meWindow.Close();
                if (OnLessonDone != null)
                    OnLessonDone(Item);
            }
        }
        private void OnQuestionDone(Question data)
        {
            if(commandType == CommandType.UPDATE)
            {
                var item = LstQuestion.Where(x => x.Id == data.Id).FirstOrDefault();
                if (item != null)
                {
                    LstQuestion[LstQuestion.IndexOf(item)] = data;
                    return;
                }
                LstQuestion.Add(data);
            }
            else
            {
               
                if (LstQuestion.Contains(data))
                {
                    Console.WriteLine("Contains Data");
                    LstQuestion[LstQuestion.IndexOf(data)] = data;
                    return;
                }
                Console.WriteLine("Not Contains Data");
                LstQuestion.Add(data);
            }
           
        }
    }
}
