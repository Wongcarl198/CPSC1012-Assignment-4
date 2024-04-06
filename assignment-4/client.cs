namespace ClientsCWong
{
    public class Client
    {
        //private fields
        private string _firstName;
        private string _lastName;
        private int _weight;
        private int _height;



        //Greedy Constructor
        public Client(string first_Name, string last_Name, int weight, int height)
        {
            FirstName = first_Name;
            LastName = last_Name;
            Weight = weight;
            Height = height; 
        }



        public string FirstName
        {
            get {return _firstName; }
            set
            {
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("First name is required. Must not be empty or blank.");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get {return _lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Last name is required. Must not be empty or blank.");
                _lastName = value.Trim();
            }
        }

        public int Weight
        {
            get {return _weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be greater than zero.");
                _weight = value;
            }
        }

        public int Height
        {
            get {return _height; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Height must be greater than zero");
                _height = value;
            }
        }

        public double BmiScore
        {
            get
            {
                double score = Weight / (Height * Height) * 703;
                return score;
            }
        }

        public string BmiStatus
        {
            get
            {
                string status = "";
                if(BmiScore <= 18.4)
                    status = "Underweight";
                if(BmiScore >= 18.5 && BmiScore <= 24.9)
                    status = "Normal";
                if(BmiScore <= 25.0 && BmiScore <= 39.9)
                    status = "Overweight";
                if(BmiScore >= 40)
                    status = "Obese";
                
                return status;
                
            }
        }

        public string FullName
        {
            get
            {
                string fullname = ($"{LastName}, {FirstName}");

                return fullname;
            }
        }



    }
}