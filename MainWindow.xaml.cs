using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinFormsApp1.CV;
using WinFormsApp1.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Applicant[] Applicants;
        bool initCandLB = true;

        public MainWindow()
        {
            string dir = Environment.CurrentDirectory;
            dir = Directory.GetParent(dir).Parent.Parent.FullName;
            dir = dir + "\\data";
            string[] files = Directory.GetFiles(dir);

            Applicants = new Applicant[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                Applicants[i] = WinFormsApp1.Json.JsonReader.GetApplicant(files[i]);
            }

            InitializeComponent();


        }

        private void CandidateListBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (initCandLB)
            {
                ListBox lb = (ListBox)sender;
                lb.Items.Clear();
                lb.ItemsSource = Applicants;
                lb.SelectedIndex = 0;
                initCandLB = false;
            }
        }

        private void CandidateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Applicant applicant = ((sender as ListBox).SelectedItem as Applicant);

            (this.FindName("NameTB") as TextBlock).Text = applicant.Name;
            (this.FindName("AgeTB") as TextBlock).Text =  applicant.Age().ToString();
            // make AgePanel invisible if age is not known
            if (applicant.Age() == 0)
                (this.FindName("AgeTB") as TextBlock).Text =  "Unknown";

            
            try{(this.FindName("LocTB") as TextBlock).Text = applicant.Loc.ToString();}
            catch (Exception) { 
                (this.FindName("LocationPanel") as StackPanel).Visibility = Visibility.Collapsed;
            }


            StringBuilder sb = new StringBuilder();
            foreach (var email in applicant.Emails)
            {
                sb.Append(email + "\n");
            }
            (this.FindName("EmailTB") as TextBlock).Text = sb.ToString();
            if (sb.Length == 0)
                (this.FindName("EmailTB") as TextBlock).Text = "Unavailable";

            
            sb.Clear();
            foreach (var phone in applicant.Phones)
            {
                sb.Append(phone + "\n");
            }
            (this.FindName("PhoneTB") as TextBlock).Text = sb.ToString();
            if (sb.Length == 0)
                (this.FindName("PhoneTB") as TextBlock).Text = "Unavailable";


            sb.Clear();
            foreach (var website in applicant.Websites)
            {
                sb.Append(website + "\n");
            }
            (this.FindName("WebsiteTB") as TextBlock).Text = sb.ToString();
            // make WebsitesPanel invisible if no websites
            if (sb.Length == 0)
                (this.FindName("WebsitesPanel") as StackPanel).Visibility = Visibility.Collapsed;
            else
                (this.FindName("WebsitesPanel") as StackPanel).Visibility = Visibility.Visible;


            (this.FindName("ProfessionTB") as TextBlock).Text = applicant.Cv.Profession;
            (this.FindName("YoETB") as TextBlock).Text = applicant.Cv.YearsOfExperience.ToString();


            (this.FindName("ObjectiveTB") as TextBlock).Text = applicant.Cv.Objective;
            // make ObjectivePanel invisible if there is no objective
            if (applicant.Cv.Objective == "")
                (this.FindName("ObjectivePanel") as StackPanel).Visibility = Visibility.Collapsed;
            else
                (this.FindName("ObjectivePanel") as StackPanel).Visibility = Visibility.Visible;


            (this.FindName("SummeryTB") as TextBlock).Text = applicant.Cv.Summery;
            // make SummeryPanel invisible if there is no summery
            if (applicant.Cv.Summery == "")
                (this.FindName("SummeryPanel") as StackPanel).Visibility = Visibility.Collapsed;
            else
                (this.FindName("SummeryPanel") as StackPanel).Visibility = Visibility.Visible;


            sb.Clear();
            foreach (var skill in applicant.Cv.Skills)
            {
                sb.Append(skill.ToString() + "\n");
            }
            (this.FindName("SkillsTB") as TextBlock).Text = sb.ToString();

            sb.Clear();
            foreach (var education in applicant.Cv.Educations)
            {
                sb.Append(education.ToString() + "\n");
            }
            (this.FindName("EduTB") as TextBlock).Text = sb.ToString();

            sb.Clear();
            foreach (var work in applicant.Cv.WorkExperiences)
            {
                sb.Append(work.ToString() + "\n");
            }
            (this.FindName("WorkTB") as TextBlock).Text = sb.ToString();

            sb.Clear();
            foreach (var lang in applicant.Cv.Languages)
            {
                sb.Append(lang.ToString() + "\n");
            }
            (this.FindName("LangTB") as TextBlock).Text = sb.ToString();

            // sb.Clear();
            // foreach (var refrence in applicant.Cv.Referees)
            // {
            //     sb.Append(refrence.ToString() + "\n");
            // }
            // (this.FindName("RefTB") as TextBlock).Text = sb.ToString();
            // // make RefereesPanel invisible if there are no refrences
            // if (sb.Length == 0)
            //     (this.FindName("RefereesPanel") as StackPanel).Visibility = Visibility.Collapsed;
            // else
            //     (this.FindName("RefereesPanel") as StackPanel).Visibility = Visibility.Visible;


            sb.Clear();
            foreach (var cert in applicant.Cv.Certifications)
            {
                sb.Append(cert.ToString() + "\n");
            }
            (this.FindName("CertTB") as TextBlock).Text = sb.ToString();
            // make CertificationsPanel invisible if there are no certifications
            if (sb.Length == 0)
                (this.FindName("CertificationsPanel") as StackPanel).Visibility = Visibility.Collapsed;
            else
                (this.FindName("CertificationsPanel") as StackPanel).Visibility = Visibility.Visible;

            sb.Clear();
            foreach (var publication in applicant.Cv.Publications)
            {
                sb.Append(publication.ToString() + "\n");
            }
            (this.FindName("PubTB") as TextBlock).Text = sb.ToString();
            // make PublicationsPanel invisible if there are no publications
            if (sb.Length == 0)
                (this.FindName("PublicationsPanel") as StackPanel).Visibility = Visibility.Collapsed;
            else
                (this.FindName("PublicationsPanel") as StackPanel).Visibility = Visibility.Visible;
            
        }
    }
}
