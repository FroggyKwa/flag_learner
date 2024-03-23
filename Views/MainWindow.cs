using FlagLearner.Database.Entities;
using FlagLearner.ViewModels;
using FlagLearner.Helpers;
using System.CodeDom;
using System.Windows.Forms;
using static FlagLearner.Database.Converters.CountryConverter;

namespace FlagLearner.Views
{
    public partial class MainWindow : Form
    {
        private MainViewModel DataContext = null!;
        private ImageList imageList = null!;
        private List<ListViewItem> listItems = null!;
        Dictionary<string, List<string>?> filters = null!;
        public MainWindow()
        {
            InitializeComponent();
            Text = "Flag Learner App";
            StartPosition = FormStartPosition.CenterScreen;
            DataContext = new MainViewModel();
            filters = new Dictionary<string, List<string>?>()
            {
                ["lines"] = new List<string>(),
                ["colors"] = new List<string>(),
                ["search_query"] = new List<string>() { "" },
            };
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            colorFilterList.Items.Clear();
            colorFilterList.DataSource = Enum.GetNames(typeof(ColorsEnum));

            lineFilterList.Items.Clear();
            lineFilterList.DataSource = Enum.GetNames(typeof(Lines));

            listItems = new List<ListViewItem>();


            LoadCountryList();
        }



        private void flagListView_DoubleClick(object sender, EventArgs e)
        {
            string item = flagListView.SelectedItems[0].SubItems[0].Text;
            if (item != null)
            {
                CountryInfoForm countryInfoForm = new(DataContext.CreateViewModel()!);
                countryInfoForm.ShowDialog();
            }
        }

        private void flagListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flagListView.SelectedItems.Count > 0)
                DataContext.selectedListIndex = flagListView.SelectedIndices[0];
        }

        private void LoadCountryList()
        {
            imageList = new ImageList();
            imageList.ImageSize = new Size(194, 129);
            flagListView.Items.Clear();
            listItems.Clear();

            DataContext.LoadCountries(filters);
            for (int i = 0; i < DataContext.countries.Count; i++)
            {
                DomainCountryModel country = DataContext.countries[i];
                imageList.Images.Add(Images.LoadImageByObj(country.ToModel()));
                listItems.Add(new ListViewItem(country.ToString(), i));
            }

            flagListView.LargeImageList = imageList;
            flagListView.Items.AddRange(listItems.ToArray());
        }

        private void lineFilterList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lineFilterList.Items.Count; i++)
            {
                if (lineFilterList.GetItemRectangle(i).Contains(lineFilterList.PointToClient(MousePosition)))
                {
                    switch (lineFilterList.GetItemCheckState(i))
                    {
                        case CheckState.Checked:
                            lineFilterList.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            lineFilterList.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }

                }

            }
        }

        private void lineFilterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = new List<string>();
            string changed_value = lineFilterList.Items[e.Index].ToString()!;
            foreach (var item in lineFilterList.CheckedItems)
            {
                checkedItems.Add(item.ToString()!);
            }
            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(changed_value.ToString());
            else
                checkedItems.Remove(changed_value);
            filters["lines"] = checkedItems.ToList();
            LoadCountryList();
        }

        private void colorFilterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            List<string> checkedItems = new List<string>();
            string changed_value = colorFilterList.Items[e.Index].ToString()!;
            foreach (var item in colorFilterList.CheckedItems)
            {
                checkedItems.Add(item.ToString()!);
            }
            if (e.NewValue == CheckState.Checked)
                checkedItems.Add(changed_value.ToString());
            else
                checkedItems.Remove(changed_value);
            filters["colors"] = checkedItems.ToList();
            LoadCountryList();
        }

        private void colorFilterList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < colorFilterList.Items.Count; i++)
            {


                if (colorFilterList.GetItemRectangle(i).Contains(colorFilterList.PointToClient(MousePosition)))
                {
                    switch (colorFilterList.GetItemCheckState(i))
                    {
                        case CheckState.Checked:
                            colorFilterList.SetItemCheckState(i, CheckState.Unchecked);
                            break;
                        case CheckState.Indeterminate:
                        case CheckState.Unchecked:
                            colorFilterList.SetItemCheckState(i, CheckState.Checked);
                            break;
                    }

                }

            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            TextBox? textBox = sender as TextBox;
            if (textBox != null)
                filters["search_query"] = new List<string> { textBox.Text };
        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                LoadCountryList();
            }
        }
    }
}