using FlagLearner.Database.Entities;
using FlagLearner.ViewModels;
using FlagLearner.Views.Common;

namespace FlagLearner.Views
{
    public partial class MainWindow : Form
    {
        MainViewModel DataContext = null!;
        public MainWindow()
        {
            InitializeComponent();
            Text = "Flag Learner App";
            StartPosition = FormStartPosition.CenterScreen;
            DataContext = new MainViewModel();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            colorFilterList.Items.Clear();
            colorFilterList.DataSource = Enum.GetNames(typeof(ColorsEnum));

            lineFilterList.Items.Clear();
            lineFilterList.DataSource = Enum.GetNames(typeof(Lines));

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(194, 129);

            List<ListViewItem> listItems = new();
            foreach(Country country in DataContext.countries)
            {
                imageList.Images.Add(Images.LoadImageByObj(country));
                listItems.Add(new ListViewItem(country.ToString(), (int)country.Id - 1));
            }

            flagListView.LargeImageList = imageList;
            flagListView.Items.AddRange(listItems.ToArray());
        }

        private void lineFilterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //TODO
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
                DataContext.selectedCountryId = flagListView.SelectedIndices[0] + 1;
        }
    }
}