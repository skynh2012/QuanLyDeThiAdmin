using QuanLyDeThi.Models;
using QuanLyDeThi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace QuanLyDeThi.ViewModels
{
    public class QuestionCommandViewModel : BaseViewModel
    {
        public CommandType commandType = CommandType.INSERT;
        public int LessonId { get; set; }
        public delegate void OnInsertOrUpdateQuestionSucces(Question data);
        public event OnInsertOrUpdateQuestionSucces OnQuestionDone;
        private ObservableCollection<AnswerItemModel> _answerItemModels;
        public ObservableCollection<AnswerItemModel> answerItemModels
        {
            get => _answerItemModels;
            set
            {
                _answerItemModels = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AnswerItemModel> _QuestionTypes;
        public ObservableCollection<AnswerItemModel> QuestionTypes
        {
            get => _QuestionTypes;
            set
            {
                _QuestionTypes = value;
                OnPropertyChanged();
            }
        }
        public Window meWindow;
        private Question _SelectedItem;
        public Question SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {

                    Answer = answerItemModels.Where(x=>x.Value.Equals(SelectedItem.Answer)).FirstOrDefault();
                    QuestionTitle = SelectedItem.QuestionTitle;
                    QuestionContent = SelectedItem.QuestionContent;
                    QuestionType = QuestionTypes.Where(x=>x.Id == SelectedItem.QuestionType).FirstOrDefault();
                    A = SelectedItem.A;
                    B = SelectedItem.B;
                    C = SelectedItem.C;
                    D = SelectedItem.D;
                }
                else
                {
                    Answer = new AnswerItemModel();
                    QuestionTitle = "";
                    QuestionContent = "";
                    QuestionType = new AnswerItemModel();
                    A = "";
                    B = "";
                    C = "";
                    D = "";
                }
            }
        }
        private string _StrButton;
        public string StrButton
        {
            get => _StrButton;
            set
            {
                _StrButton = value;
                OnPropertyChanged();
            }
        }
        private AnswerItemModel _Answer;
        public AnswerItemModel Answer
        {
            get => _Answer;
            set
            {
                _Answer = value;
                OnPropertyChanged();
                Console.WriteLine(_Answer == null);
                if (_Answer != null)
                {
                    Console.WriteLine(_Answer.Value);
                }
            }
        }
        private string _QuestionTitle;
        public string QuestionTitle
        {
            get => _QuestionTitle;
            set
            {
                _QuestionTitle = value;
                OnPropertyChanged();
            }
        }
        private string _QuestionContent;
        public string QuestionContent
        {
            get => _QuestionContent;
            set
            {
                _QuestionContent = value;
                OnPropertyChanged();
            }
        }
        private AnswerItemModel _QuestionType;
        public AnswerItemModel QuestionType
        {
            get => _QuestionType;
            set
            {
                _QuestionType = value;
                OnPropertyChanged();
            }
        }

        private string _A;
        public string A
        {
            get => _A;
            set
            {
                _A = value;
                OnPropertyChanged();
            }
        }
        private string _B;
        public string B
        {
            get => _B;
            set
            {
                _B = value;
                OnPropertyChanged();
            }
        }
        private string _C;
        public string C
        {
            get => _C;
            set
            {
                _C = value;
                OnPropertyChanged();
            }
        }
        private string _D;
        public string D
        {
            get => _D;
            set
            {
                _D = value;
                OnPropertyChanged();
            }
        }



        public ICommand ButtonCommand { get; set; }

        public QuestionCommandViewModel()
        {
            answerItemModels = new ObservableCollection<AnswerItemModel>()
            {
                new AnswerItemModel(){Id = 1,Value = "A"},
                new AnswerItemModel(){Id = 2,Value = "B"},
                new AnswerItemModel(){Id = 3,Value = "C"},
                new AnswerItemModel(){Id = 4,Value = "D"}
            };
            QuestionTypes = new ObservableCollection<AnswerItemModel>()
            {
                new AnswerItemModel(){Id = 0,Value = "Lý thuyết"},
                new AnswerItemModel(){Id = 1,Value = "Thực hành"},
                new AnswerItemModel(){Id = 2,Value = "Quy tắc"}
            };
            Console.WriteLine(QuestionTypes.Count);
            Console.WriteLine(answerItemModels.Count);
            ButtonCommand = new RelayCommand<object>((p) => { return true; }, OnButtonClicked);
        }

        private void OnButtonClicked(object sender)
        {
            Console.WriteLine("Button Clicked 2");
            if (commandType == CommandType.INSERT)
            {
                
                if (SelectedItem != null)
                {
                    
                    SelectedItem.ModifyDate = DateTime.Now;
                    SelectedItem.A = A;
                    SelectedItem.B = B;
                    SelectedItem.C = C;
                    SelectedItem.D = D;
                    SelectedItem.Answer = Answer.Value;
                    SelectedItem.QuestionContent = QuestionContent;
                    SelectedItem.QuestionTitle = QuestionTitle;
                    SelectedItem.QuestionType = QuestionType.Id;
                    MessageBox.Show("Cập nhật bài thi thành công !");
                    if (meWindow != null)
                        meWindow.Close();
                    if (OnQuestionDone != null)
                        OnQuestionDone(SelectedItem);
                }
                else
                {
                    var Item = new Question();
                    Item.ModifyDate = DateTime.Now;
                    Item.CreateDate = DateTime.Now;
                    Item.A = A;
                    Item.B = B;
                    Item.C = C;
                    Item.D = D;
                    Item.Answer = Answer.Value;
                    Item.QuestionContent = QuestionContent;
                    Item.QuestionTitle = QuestionTitle;
                    Item.QuestionType = QuestionType.Id;
                    MessageBox.Show("Thêm bài thi thành công !");
                    if (meWindow != null)
                        meWindow.Close();
                    if (OnQuestionDone != null)
                        OnQuestionDone(Item);
                }
            }
            else if (commandType == CommandType.UPDATE)
            {
                Console.WriteLine("Button Clicked 3");
                if (SelectedItem != null)
                {
                    var Item = DataProvider.Instance.DB.Questions.Where(x => x.Id == SelectedItem.Id).FirstOrDefault();
                    if (Item != null)
                    {
                        Console.WriteLine("Button Clicked 4");
                        Item.LessonId = SelectedItem.LessonId;
                        Item.QuestionType = QuestionType.Id;
                        Item.QuestionTitle = QuestionTitle;
                        Item.QuestionContent = QuestionContent;
                        Item.A = A;
                        Item.B = B;
                        Item.C = C;
                        Item.D = D;
                        Item.Answer = Answer.Value;
                        Item.ModifyDate = DateTime.Now;
                        DataProvider.Instance.DB.SaveChanges();
                        MessageBox.Show("Cập nhật bài thi thành công !");
                        if (meWindow != null)
                            meWindow.Close();
                        if (OnQuestionDone != null)
                            OnQuestionDone(Item);
                    }
                    Console.WriteLine("Button Clicked 5");
                }
                else
                {
                    Console.WriteLine("Button Clicked 6");
                    var Item = new Question();
                    Item.ModifyDate = DateTime.Now;
                    Item.CreateDate = DateTime.Now;
                    Item.A = A;
                    Item.B = B;
                    Item.C = C;
                    Item.D = D;
                    Item.Answer = Answer.Value;
                    Item.QuestionContent = QuestionContent;
                    Item.QuestionTitle = QuestionTitle;
                    Item.QuestionType = QuestionType.Id;
                    Item.LessonId = LessonId;
                    DataProvider.Instance.DB.Questions.Add(Item);
                    DataProvider.Instance.DB.SaveChanges();
                    MessageBox.Show("Thêm bài thi thành công !");
                    if (meWindow != null)
                        meWindow.Close();
                    if (OnQuestionDone != null)
                        OnQuestionDone(Item);
                }
            }



        }

        private bool CheckSpace(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;
            return false;
        }
    }
}
