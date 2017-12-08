using SQLite4Unity3d;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class Teddy  {

	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public int Age { get; set; }
        public byte[] Pic { get; set; }
        //public Texture2D img { get; set; }
        public string Str { get; set; }

    public override string ToString ()
	{
        Str = Encoding.ASCII.GetString(Pic);

        return string.Format ("[Teddy: Id={0}, Name={1},  Surname={2}, Age={3}, Str={4}]", Id, Name, Surname, Age, Pic[0]);
	}
}
