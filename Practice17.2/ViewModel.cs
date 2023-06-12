using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Practice17_2
{
    internal class ViewModel : INotifyPropertyChanged
    {
        Practice16Entities context = new Practice16Entities();
        public BindingList<Users> Users { get; set; }
        public BindingList<Goods> Goods { get; set; }
        RelayCommand addCommandUser;
        RelayCommand editCommandUser;
        RelayCommand deleteCommandUser;
        RelayCommand addCommandGood;
        RelayCommand editCommandGood;
        RelayCommand deleteCommandGood;
        int selectedUserIndex;
        public int SelectedUserIndex { get { return selectedUserIndex; }
            set
            {
                selectedUserIndex = value;
                if (selectedUserIndex >= 0 && selectedUserIndex < Users.Count)
                    { } // если закомментировать эту строку и раскомментировать следующую, почему-то происходит ошибка NullReferenceException при добавлении новой записи Users
                    //Goods = new BindingList<Goods>((from g in context.Goods.Local where g.email == Users[selectedUserIndex].email select g).ToList());
                else if (selectedUserIndex == -1)
                    Goods = context.Goods.Local.ToBindingList();
                else
                    Goods = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Goods)));
            }
        }
        public int SelectedGoodIndex {get;set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            context.Users.Load();
            Users = context.Users.Local.ToBindingList();
            context.Goods.Load();
            Goods = context.Goods.Local.ToBindingList();
        }

        public RelayCommand AddCommandUser
        {
            get
            {
                return addCommandUser ??
                  (addCommandUser = new RelayCommand((o) =>
                  {
                      UserWindow userWindow = new UserWindow(new Users());
                      if (userWindow.ShowDialog() == true)
                      {
                          Users user = userWindow.User;
                          context.Users.Add(user);
                          context.SaveChanges();
                      }
                  }));
            }
        }

        public RelayCommand EditCommandUser
        {
            get
            {
                return editCommandUser ??
                  (editCommandUser = new RelayCommand((selectedItem) =>
                  {
                      Users user = selectedItem as Users;
                      if (user == null) return;

                      Users vm = new Users
                      {
                          Id = user.Id,
                          lastName = user.lastName,
                          firstName = user.firstName,
                          middleName = user.middleName,
                          phoneNumber = user.phoneNumber,
                          email = user.email
                      };
                      UserWindow userWindow = new UserWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          user.firstName = userWindow.User.firstName;
                          user.lastName = userWindow.User.lastName;
                          user.middleName = userWindow.User.middleName;
                          user.phoneNumber = userWindow.User.phoneNumber;
                          if (userWindow.User.email != user.email)
                          {
                              var userGoods = Goods.Where(e => e.email == user.email);
                              foreach (Goods g in userGoods)
                              {
                                  g.email = userWindow.User.email;
                                  context.Entry(g).State = EntityState.Modified;
                              }
                              user.email = userWindow.User.email;
                          }
                          context.Entry(user).State = EntityState.Modified;
                          context.SaveChanges();
                      }
                  }));
            }
        }

        public RelayCommand DeleteCommandUser
        {
            get
            {
                return deleteCommandUser ??
                  (deleteCommandUser = new RelayCommand((selectedItem) =>
                  {
                      Users user = selectedItem as Users;
                      if (user == null) return;
                      if (MessageBox.Show($"Удалить {user}?", "Practice 17", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                      {
                          context.Users.Remove(user);
                          context.SaveChanges();
                      }
                  }));
            }
        }

        public RelayCommand AddCommandGood
        {
            get
            {
                return addCommandGood ??
                  (addCommandGood = new RelayCommand((o) =>
                  {
                      GoodWindow goodWindow = new GoodWindow(new Goods(), Users, selectedUserIndex);
                      if (goodWindow.ShowDialog() == true)
                      {
                          Goods good = goodWindow.Good;
                          context.Goods.Add(good);
                          context.SaveChanges();
                      }
                  }));
            }
        }

        public RelayCommand EditCommandGood
        {
            get
            {
                return editCommandGood ??
                  (editCommandGood = new RelayCommand((selectedItem) =>
                  {
                      Goods good = selectedItem as Goods;
                      if (good == null) return;

                      Goods vm = new Goods
                      {
                          Id = good.Id,
                          email = good.email,
                          code = good.code,
                          goodName = good.goodName
                      };
                      GoodWindow goodWindow = new GoodWindow(vm, Users, Users.IndexOf(Users.Where(e => e.email == Goods[SelectedGoodIndex].email).First()));

                      if (goodWindow.ShowDialog() == true)
                      {
                          good.email = goodWindow.Good.email;
                          good.code = goodWindow.Good.code;
                          good.goodName = goodWindow.Good.goodName;
                          context.Entry(good).State = EntityState.Modified;
                          context.SaveChanges();
                      }
                  }));
            }
        }

        public RelayCommand DeleteCommandGood
        {
            get
            {
                return deleteCommandGood ??
                  (deleteCommandGood = new RelayCommand((selectedItem) =>
                  {
                      Goods good = selectedItem as Goods;
                      if (good == null) return;
                      if (MessageBox.Show($"Удалить {good}?", "Practice 17", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                      {
                          context.Goods.Remove(good);
                          context.SaveChanges();
                      }
                  }));
            }
        }

    }
}
