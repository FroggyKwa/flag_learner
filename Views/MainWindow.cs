using FlagLearner.Database.Entities;
using FlagLearner.ViewModels;
using FlagLearner.Views.Common;

namespace FlagLearner.Views
{
    public partial class MainWindow : Form
    {
        MainViewModel vm = null!;
        public MainWindow()
        {
            InitializeComponent();
            Text = "Flag Learner App";
            StartPosition = FormStartPosition.CenterScreen;
            vm = new MainViewModel();
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
            for (int i = 0; i < vm.countries.Count; i++)
            {
                Country country = vm.countries[i];
                imageList.Images.Add(Images.LoadImageByObj(country));
                listItems.Add(new ListViewItem(vm.countries[i].ToString(), i));
            }

            flagListView.LargeImageList = imageList;
            flagListView.Items.AddRange(listItems.ToArray());
        }

        private void lineFilterList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //TODO
        }
    }
}