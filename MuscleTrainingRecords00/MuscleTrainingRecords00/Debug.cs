using System;
using SQLite;
using Xamarin.Forms;

namespace MuscleTrainingRecords00
{
    public class Debug : ContentPage
    {
        public Debug(){}
        protected  override void OnAppearing()
        {
            
            var s2 = new StackLayout();
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath)){
                try{
                    s2.Children.Add(new Label { Text = "RecordModel" });
                    var rmList = db.Query<RecordsModel>("SELECT * FROM [Records]");
                    foreach (RecordsModel rm in rmList)
                    {
                        s2.Children.Add(new Label { Text = "Mno = " + rm.M_no + " Mname = " + rm.M_name });
                    }
                    s2.Children.Add(new Label { Text = "RecordModelv2" });
                    var rm2List = db.Query<RecordModelv2>("SELECT * FROM [Re]");
                    foreach (RecordModelv2 rev2 in rm2List)
                    {
                        s2.Children.Add(new Label { Text = "Mno = " + rev2.M_no + " Mname = " + rev2.M_name });
                    }
                } catch (SQLiteException ex){
                    s2.Children.Add(new Label { Text = "NO DATA" });
                }

            }

            var s = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" },
                    new ScrollView{Orientation=ScrollOrientation.Vertical,
                        Content = s2
                    }
                }
            };
            Content = s;
        }
    }

}

