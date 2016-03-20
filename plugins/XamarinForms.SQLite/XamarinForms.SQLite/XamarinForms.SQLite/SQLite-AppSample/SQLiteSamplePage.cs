using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamarinForms.SQLite.SQLite;

namespace XamarinForms.SQLite
{
    public class SQLiteSamplePage
    {
        private readonly SQLiteConnection _sqLiteConnection;

        public SQLiteSamplePage()
        {

            _sqLiteConnection = DependencyService.Get<ISQLite>().GetConnection();

            _sqLiteConnection.CreateTable<TodoItem>();

            // ADD
            _sqLiteConnection.Insert(new TodoItem
            {
                Text = "Tutorial about SQLite",
                Done = false,
            });

            // UPDATE
            _sqLiteConnection.Update(new TodoItem
            {
                ID = 1,
                Text = "Creating a tutorial about SQLite",
                Done = true,
            });

            _sqLiteConnection.Insert(new TodoItem
            {
                Text = "Meeting Friends at 11 AM",
                Done = true,
            });

            // DELETE
            _sqLiteConnection.Delete<TodoItem>(2);
        }

        /// <summary>
        /// Gets a ContentPage that contains the items saved in the SQLite database.
        /// </summary>
        /// <returns></returns>
        public ContentPage GetSampleContentPage()
        {

            var entry = new Entry
            {
                Placeholder = "Text",
                WidthRequest = 300
            };

            var switcher = new Switch();

            var button = new Button
            {
                Text = "Add TodoItem"
            };
            button.Clicked += (s, e) =>
            {
                _sqLiteConnection.Insert(new TodoItem
                {
                    Text = entry.Text,
                    Done = switcher.IsToggled,
                });
            };

            var contentPage = new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "SQLite Sample",
                            FontSize = 50
                        },
                        new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                entry,
                                switcher,
                            }
                        },
                        button,
                        new ListView
                        {
                            ItemsSource = _sqLiteConnection.Table<TodoItem>()
                        }
                    }
                }
            };

            return contentPage;
        }
    }
}
