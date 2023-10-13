using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var grendFather = new AdultFamilyMember() { Mother = null, Father = null, Name = "Bob", Sex = Gender.Male};
            var grendMather = new AdultFamilyMember() { Mother = null, Father = null, Name = "Ann", Sex = Gender.Female };
            var father = new AdultFamilyMember() { Mother = grendMather, Father = grendFather, Name = "Karl", Sex = Gender.Male };
            var mather = new AdultFamilyMember() { Mother = null, Father = null, Name = "Karla", Sex = Gender.Female };
            var son1 = new AdultFamilyMember() { Mother = mather, Father = father, Name = "Adam", Sex = Gender.Male };
            var son2 = new FamilyMember() { Mother = mather, Father = father, Name = "Sem", Sex = Gender.Male };
            var daughter1 = new FamilyMember() { Mother = mather, Father = father, Name = "Mery",Sex = Gender.Female };
            var daughter2 = new FamilyMember() { Mother = mather, Father = father, Name = "Samanta", Sex = Gender.Female };
            var eva = new AdultFamilyMember() { Mother = null, Father = null, Name = "Eva", Sex = Gender.Female };
            var kain = new FamilyMember() { Mother = son1, Father = eva, Name = "Kain", Sex = Gender.Male };

            grendFather.Wedding(grendMather);
            father.Wedding(mather);
            grendFather.AddChildren(father);
            father.AddChildren(son1);
            father.AddChildren(son2);
            father.AddChildren(daughter1);
            father.AddChildren(daughter2);
            son1.Wedding(eva);
            son1.AddChildren(kain);

            grendFather.Print(2);
            Console.ReadLine();
        }
    }
}
