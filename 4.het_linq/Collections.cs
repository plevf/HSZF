using _4.het_linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

List<Student> groupA = new List<Student>()
{
    new Student("Edward", 180, 5),
    new Student("Alice", 165, 1),
    new Student("Michael", 175, 2),
    new Student("Sophie", 170, 3),
    new Student("Daniel", 185, 4)
};
List<Student> groupB = new List<Student>()
{
    new Student("Oliver", 178, 6),
    new Student("Emma", 162, 7),
    new Student("James", 181, 8),
    new Student("Charlotte", 168, 9),
    new Student("William", 184, 10),
    new Student("Amelia", 159, 11),
    new Student("Benjamin", 176, 12),
    new Student("Grace", 164, 13),
    new Student("Sophie", 170, 3),
    new Student("Daniel", 185, 4)
};

IEnumerable<Student> metszet = groupA.Intersect(groupB);
IEnumerable<Student> unio = groupA.Union(groupB);
IEnumerable<Student> kulonbseg = groupA.Except(groupB);

//igy nem megy mert ehhez kene Equals es GetHashCode feluliras, tehat:

var students = new Student[]
{
    new Student("John", 182, 4),
    new Student("Liza", 166, 5),
    new Student("Carlos", 177, 3),
    new Student("James", 185, 4),
    new Student("Jack", 156, 2),
    new Student("Kate", 174, 5),
};


List<Student> groupC = new List<Student>();

List<Student> groupD = new List<Student>();

groupA.Add(students[0]); // ezek azert mukodnek mert PONTOSAN ugyanazt a peldanyt adtam at mindket tombbe pl amikor azonosak (tehat ua az objektum)
groupA.Add(students[1]);
groupA.Add(students[2]);
groupA.Add(students[3]);

groupB.Add(students[0]);
groupB.Add(students[4]);
groupB.Add(students[5]);
groupB.Add(students[3]);

var intersect = groupA.Intersect(groupB);

var union = groupA.Union(groupB);

var diff = groupA.Except(groupB);

//Írjuk meg a lekérdezéseket az alábbi feladatokra:

var kisebb180nal = students.Any(p => p.Height > 180); //Van - e 180 cm - nél magasabb gyerek?
var bukottE = students.All(p => p.Mark != 1); //Igaz - e, hogy senki nem bukott meg?
var jobbMint3 = students.Where(p => p.Mark > 3); //Kik a 3 - asnál jobb tanulók?
//Hányan magasabbak 170 cm - nél ?
//Ki a legjobb tanuló?
//Ki a 3 legjobb tanuló?
//Mi a 3 legjobb tanuló neve ?

var magasabbMint170 = students.Count(p => p.Height > 170);
                        
var legjobbTanulo = students.OrderByDescending(p => p.Mark).First();

var haromLegjobb = students.OrderByDescending(p => p.Mark).Take(3);
var haromLegjobbNeve = students
    .OrderByDescending(p => p.Mark)
    .Take(3)
    .Select(t => t.Name);
//ua
var haromLegjobbNeve2 = from t in students
                        orderby t.Mark descending
                        select t.Name.Take(3);

