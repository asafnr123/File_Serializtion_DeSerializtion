using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_DeSerializtion_Serializtion
{
    public class Car
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        private int codan;

        public int numberOfSeats;

        public Car() {}

        public Car(string model, string brand, int year, string color, int codan, int numberOfSeats)
        {
            Model = model;
            Brand = brand;
            Year = year;
            Color = color;
            this.codan = codan;
            this.numberOfSeats = numberOfSeats;
        }

        public int GetCodan()
        {
            return codan;
        }

        public int GetNumberOfSeats()
        {
            return numberOfSeats;
        }

        public void ChangeNumberOfSeats(int newNumber)
        {
            numberOfSeats = newNumber;
        }

        public override string ToString()
        {
            return $"Model: {Model} \n" +
                $"Brand: {Brand} \n" +
                $"Year: {Year} \n" +
                $"Color: {Color} \n" +
                $"Seat Number: {numberOfSeats}";
        }
    }
}
