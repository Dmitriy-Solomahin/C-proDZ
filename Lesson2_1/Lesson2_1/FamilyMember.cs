using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_1
{
    public enum Gender { 
        Male,
        Female
    }
    public class FamilyMember{
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }

        public virtual void Info(int index) {
            Console.WriteLine($"{new String(' ', index)} -- {this.Name}");
        }
        public virtual void Print(int indent = 0)
        {
            Info(indent);
        }
    }

    public class AdultFamilyMember : FamilyMember
    {
        public AdultFamilyMember spouse { get; set; }
        public List<FamilyMember> children { get; set; } = new List<FamilyMember>();

        public override void Info(int index){
            Console.WriteLine($"{new String(' ', index)} -- {this.Name} + {spouse.Name}");
            Console.WriteLine($"{new String(' ', index + 4)} |");
            Console.WriteLine($"{new String(' ', index + 4)} |");
        }
        public override void Print(int indent = 0)
        {
            base.Print(indent);

            foreach (var child in children)
                child.Print(indent + 4);
        }

        public void AddChildren(FamilyMember child)
        {
            children.Add(child);
            spouse.children.Add(child);
        }

        public void Wedding(AdultFamilyMember spouse)
        {
            this.spouse = spouse;
            spouse.spouse = this;
        }



    }
}
