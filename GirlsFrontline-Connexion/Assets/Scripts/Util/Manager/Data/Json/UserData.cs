namespace Util.Manager.Data.Json
{
    public class Chapter
    {
        public bool IsLocked { get; set; } = false;
    }

    public class Volume
    {
        public float Background { get; set; } = 0.5f;
        public float Effect { get; set; } = 0.5f;
        public float Voice { get; set; } = 0.5f;
    }

    public class Option
    {
        public Volume Volume { get; set; } = new Volume();
        public bool IsStorySkipped { get; set; } = false;
    }
    
    public class UserData
    {
        public Chapter Chapter01 { get; set; } = new Chapter();
        public Chapter Chapter02 { get; set; } = new Chapter();
        public Chapter Chapter03 { get; set; } = new Chapter();
        public Chapter Chapter04 { get; set; } = new Chapter();
        public Chapter Chapter05 { get; set; } = new Chapter();

        public Option Option { get; set; } = new Option();
    }
}
