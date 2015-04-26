using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VideoPoker.Model;

namespace VideoPoker.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private PlayerModel _Player1;
        public PlayerModel Player1 { get { return _Player1; } set { _Player1 = value; RaisePropertyChanged("Player1"); } }

        private PlayerModel _Player2;
        public PlayerModel Player2 { get { return _Player2; } set { _Player2 = value; RaisePropertyChanged("Player2"); } }

        private DealerModel _Dealer;
        public DealerModel Dealer { get { return _Dealer; } set { _Dealer = value; RaisePropertyChanged("Dealer"); } }


        public ICommand ChangeCommand { get; set; }
        public ICommand SortCommand { get; set; }
        public ICommand RestartCommand { get; set; }
        
        public MainViewModel()
        {
            Player1 = PlayerModel.Deserialize<PlayerModel>("Player1") ?? new PlayerModel();
            Player2 = PlayerModel.Deserialize<PlayerModel>("Player2") ?? new PlayerModel();
            Init();

            // チェックが入っていない手札を入れ替える、入れ替えは１回まで有効とする
            ChangeCommand = CreateCommand(
                (v) => {var player = v as PlayerModel;
                    player.Holds.Select((b, i) => new { Index = i, IsHold = b })
                    .Where(a => !a.IsHold).ToList()
                    .ForEach(a => player.Change(a.Index, Dealer.Pass()));
                    player.Holds = new ObservableCollection<bool>() { false, false, false, false, false };},
                (v) => { return v == null ? false : (v as PlayerModel).ChangeCount < 1; }
            );
            // カードを並び替える
            SortCommand = CreateCommand(
                (v) => { var player = v as PlayerModel; 
                    player.CardModels = new ObservableCollection<CardModel>(player.CardModels.OrderBy(w => w)); }, 
                (v) => {return true;}
            );
            // ゲームを最初からやり直す
            RestartCommand = CreateCommand(
                (v) => { Player1.Reset(); Player2.Reset(); Dealer.Reset(); Init(); }, 
                (v) => { return true; }
            );
        }

        private void Init()
        {
            Dealer = DealerModel.Current;
            
            // プレイヤーがディーラーから手札を５枚受け取る
            if(Player1.CardModels.Contains(null))
                Dealer.Pass(5).Select((v, i) => new{Index = i, Card = v}).ToList().ForEach(a => Player1.Change(a.Index, a.Card, true));
            if (Player2.CardModels.Contains(null))
                Dealer.Pass(5).Select((v, i) => new { Index = i, Card = v }).ToList().ForEach(a => Player2.Change(a.Index, a.Card, true));
        }

        ~MainViewModel()
        {
            Player1.Serialize("Player1");
            Player2.Serialize("Player2");
        }
    }
}
