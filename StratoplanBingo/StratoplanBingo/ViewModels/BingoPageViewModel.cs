using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using StratoplanBingo.Dictionaries;
using StratoplanBingo.Extensions;
using StratoplanBingo.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace StratoplanBingo.ViewModels
{
    public class BingoPageViewModel : BaseViewModel
    {
        enum BingoColumns
        {
            First, Second, Third, Fourth, Fifth
        }

        public BingoPageViewModel()
        {
            NumberTappedCommand = new Command<BingoCard>(async (number) => await ExecuteNumberTappedCommand(number));

            var shuffled = new List<int>();
            shuffled.AddRange(Enumerable.Range(1, Storage.BingoValues.Count));
            shuffled.Shuffle();

            FirstColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.First, shuffled.GetRange(0, 5)));
            SecondColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Second, shuffled.GetRange(5, 5)));
            ThirdColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Third, shuffled.GetRange(10, 5)));
            FourthColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Fourth, shuffled.GetRange(15, 5)));
            FifthColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Fifth, shuffled.GetRange(20, 5)));
        }

        ObservableRangeCollection<BingoCard> firstColumn;
        public ObservableRangeCollection<BingoCard> FirstColumn { get => firstColumn; set => SetProperty(ref firstColumn, value); }

        ObservableRangeCollection<BingoCard> secondColumn;
        public ObservableRangeCollection<BingoCard> SecondColumn { get => secondColumn; set => SetProperty(ref secondColumn, value); }

        ObservableRangeCollection<BingoCard> thirdColumn;
        public ObservableRangeCollection<BingoCard> ThirdColumn { get => thirdColumn; set => SetProperty(ref thirdColumn, value); }

        ObservableRangeCollection<BingoCard> fourthColumn;
        public ObservableRangeCollection<BingoCard> FourthColumn { get => fourthColumn; set => SetProperty(ref fourthColumn, value); }

        ObservableRangeCollection<BingoCard> fifthColumn;
        public ObservableRangeCollection<BingoCard> FifthColumn { get => fifthColumn; set => SetProperty(ref fifthColumn, value); }

        public ICommand NumberTappedCommand { get; }

        void ExecuteResetCardsCommand()
        {
            var shuffled = new List<int>();
            shuffled.AddRange(Enumerable.Range(1, 29));
            shuffled.Shuffle();

            FirstColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.First, shuffled.GetRange(0, 5)));
            SecondColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Second, shuffled.GetRange(5, 5)));
            ThirdColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Third, shuffled.GetRange(10, 5)));
            FourthColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Fourth, shuffled.GetRange(15, 5)));
            FifthColumn = new ObservableRangeCollection<BingoCard>(InitializeColumn(BingoColumns.Fifth, shuffled.GetRange(20, 5)));
        }

        async Task ExecuteNumberTappedCommand(BingoCard number)
        {
            if (number.Selected)
                number.Selected = false;
            else
                number.Selected = true;

            if (CheckWinners())
            {
                var displayTask = Shell.Current.DisplayAlert("Победа!", "Ура, это победа дорогие товарищи!", "Перемешать", "Пойти нахуй");

                await Task.WhenAll(displayTask);

                if (displayTask.Result == true)
                {
                    ExecuteResetCardsCommand();
                }
            }
        }

        bool CheckWinners()
        {           
            // 1 колонка
            if (FirstColumn[0].Selected && FirstColumn[1].Selected && FirstColumn[2].Selected && FirstColumn[3].Selected && FirstColumn[4].Selected)
                return true;

            // 2
            if (SecondColumn[0].Selected && SecondColumn[1].Selected && SecondColumn[2].Selected && SecondColumn[3].Selected && SecondColumn[4].Selected)
                return true;

            // 3
            if (ThirdColumn[0].Selected && ThirdColumn[1].Selected && ThirdColumn[2].Selected && ThirdColumn[3].Selected && ThirdColumn[4].Selected)
                return true;

            // 4
            if (FourthColumn[0].Selected && FourthColumn[1].Selected && FourthColumn[2].Selected && FourthColumn[3].Selected && FourthColumn[4].Selected)
                return true;

            // 5
            if (FifthColumn[0].Selected && FifthColumn[1].Selected && FifthColumn[2].Selected && FifthColumn[3].Selected && FifthColumn[4].Selected)
                return true;

            // диагонали
            if (FirstColumn[0].Selected && SecondColumn[1].Selected && ThirdColumn[2].Selected && FourthColumn[3].Selected && FifthColumn[4].Selected)
                return true;

            if (FirstColumn[4].Selected && SecondColumn[3].Selected && ThirdColumn[2].Selected && FourthColumn[1].Selected && FifthColumn[0].Selected)
                return true;

            // горизонтали
            if (FirstColumn[0].Selected && SecondColumn[0].Selected && ThirdColumn[0].Selected && FourthColumn[0].Selected && FifthColumn[0].Selected)
                return true;

            if (FirstColumn[1].Selected && SecondColumn[1].Selected && ThirdColumn[1].Selected && FourthColumn[1].Selected && FifthColumn[1].Selected)
                return true;

            if (FirstColumn[2].Selected && SecondColumn[2].Selected && ThirdColumn[2].Selected && FourthColumn[2].Selected && FifthColumn[2].Selected)
                return true;

            if (FirstColumn[3].Selected && SecondColumn[3].Selected && ThirdColumn[3].Selected && FourthColumn[3].Selected && FifthColumn[3].Selected)
                return true;

            if (FirstColumn[4].Selected && SecondColumn[4].Selected && ThirdColumn[4].Selected && FourthColumn[4].Selected && FifthColumn[4].Selected)
                return true;

            return false;
        }

        List<BingoCard> InitializeColumn(BingoColumns column, List<int> shuffled)
        {
            List<BingoCard> numbers = new List<BingoCard>();

            for (var rowPosition = 0; rowPosition < 5; rowPosition++)
            {
                numbers.Add(new BingoCard
                {
                    Column = column.ToString(),
                    Number = shuffled[rowPosition],
                    Value = Storage.BingoValues.Where(x => x.Key == shuffled[rowPosition]).FirstOrDefault().Value,
                    RowPosition = rowPosition
                });
            }

            return numbers;
        }
    }    
}
