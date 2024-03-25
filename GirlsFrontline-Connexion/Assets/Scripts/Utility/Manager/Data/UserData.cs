using System;

namespace Utility.Manager.Data
{
    public class Chapter
    {
        public bool IsLocked { get; set; } = true;
    }

    public class Volume
    {
        public float Background { get; set; } = -30f;
        
        public float Effect { get; set; } = -30f;
        
        public float Voice { get; set; } = -30f;
    }

    public class IsMute
    {
        public bool Background { get; set; }

        public bool Effect { get; set; }

        public bool Voice { get; set; }
    }

    public class Option
    {
        public Volume Volume { get; set; } = new Volume();

        public IsMute IsMute { get; set; } = new IsMute();
    }
    
    public class UserData
    {
        public UserData()
        {
            Chapter01.IsLocked = false;
        }
        
        public Chapter Chapter01 { get; set; } = new Chapter();
        public Chapter Chapter02 { get; set; } = new Chapter();
        public Chapter Chapter03 { get; set; } = new Chapter();
        public Chapter Chapter04 { get; set; } = new Chapter();
        public Chapter Chapter05 { get; set; } = new Chapter();

        public Option Option { get; set; } = new Option();

        public Chapter GetChapter(int index)
        {
            switch (index)
            {
                case 0: return Chapter01;
                case 1: return Chapter02;
                case 2: return Chapter03;
                case 3: return Chapter04;
                case 4: return Chapter05;
                default: throw new NotImplementedException();
            }
        }
    }
}
