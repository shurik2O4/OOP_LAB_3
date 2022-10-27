namespace OOP_LAB_3 {
    public struct CatData {
        public string Name;
        public double Age;
        public Gender Gender;
        public CatType Type;
    }
    public class Cat {
        private string name;
        public string Name { get => name; set {
                if (value == "" || value == null) {
                    throw new ArgumentException("Name cannot be empty string or null");
                }
                name = value;
            }
        }

        private double age;
        public double Age {
            get => age;
            set {
                if (value <= 0) {
                    throw new ArgumentException("Age must be greater than 0");
                }

                age = value;
            }
        }

        private static int _id = 1;
        private readonly int id;
        public int Id { get => id; }

        private Gender gender;
        public Gender Gender { get => gender; set => gender = value; }


        private CatType type;
        public CatType Type { get => type; set => type = value; }
        public Cat() : this(Utils.FillOutCat()) {}
        public Cat(CatData data) : this(data.Name, data.Age, data.Gender, data.Type) {}

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        public Cat(string name, double age, Gender gender, CatType type) {
            Name = name ?? throw new ArgumentNullException("Name", "Name cannot be null");
            id = _id++;
            Age = age;
            Gender = gender;
            Type = type;
        }
#pragma warning restore CS8618


        public void Purr() {
            Console.WriteLine($"[{name}] Purr...");
        }
        public void Meow() {
            Console.WriteLine($"[{name}] Meow!");
        }
        public void Eat() {
            Eat(Utils.FoodTypeForCatQuestion());
        }

        public void Eat(FoodType foodType) {
            Console.WriteLine($"[{name}] Eating {foodType}...");
        }

        public override string ToString() => $"Cat(name: {Name}, age: {Age} year(s), gender: {Gender}, type: {Type})";

        public void Deconstruct(out string name, out double age, out Gender gender, out CatType type) {
            name = this.name;
            age = this.age;
            gender = this.gender;
            type = this.type;
        }
    }
}