namespace ClientsCWong
{
    public class Client
    {
        //private fields
        private string _firstName;
        private string _lastName;
        private double _weight;
        private double _height;




        public Client()
        {
            FirstName = "XXXXX";
            LastName = "XXXXX";
        }

        //Greedy Constructor
        public Client(string firstName, string lastName, double weight, double height)
        {
            FirstName = firstName;
            LastName = lastName;
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

        public double Weight
        {
            get {return _weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be greater than zero.");
                _weight = value;
            }
        }

        public double Height
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
                double score = (Weight / (Height * Height) * 703);
                return score;
            }
        }

        public string BmiStatus
        {
            get
            {
                double score = BmiScore;
                string status = "";
                if(score <= 18.4)
                {
                    status = "Underweight";
                }
                else if(score >= 18.5 && score <= 24.99)
                {
                    status = "Normal";
                }
                else if(score >= 25.0 && score <= 39.99)
                {
                    status = "Overweight";
                }
                else if(score >= 40)
                {
                    status = "Obese";
                }
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