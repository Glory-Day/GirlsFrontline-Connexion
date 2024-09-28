using GloryDay.Log;
using GloryDay.UI;

namespace UI
{
    public class MainInterfaceScreen : ScreenBase
    {
        private StageClearAnimation _stageClearAnimation;
        
        private ChapterInformationDisplayGroup _chapterInformationDisplays;
        private readonly CharacterStatPointDisplay[] _characterStatPointDisplays = new CharacterStatPointDisplay[5];
        
        private StageProgressDisplay _stageProgressDisplay;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            // Initialize chapter information display components.
            var child = transform.GetChild(3);
            _chapterInformationDisplays = child.GetComponent<ChapterInformationDisplayGroup>();
            
            // Initialize clear state display component.
            _stageClearAnimation = transform.GetChild(4).GetComponent<StageClearAnimation>();

            // Initialize input system of information display. 
            child = transform.GetChild(5);
            InformationDisplayHandler = child.GetComponent<InformationDisplayHandler>();
            
            // Initialize skill information display components.
            child = transform.GetChild(5).GetChild(0);
            SkillInformationDisplays[0] = child.GetChild(0).GetComponent<SkillInformationDisplay>();
            SkillInformationDisplays[1] = child.GetChild(1).GetComponent<SkillInformationDisplay>();
            SkillInformationDisplays[2] = child.GetChild(2).GetComponent<SkillInformationDisplay>();

            // Initialize character stat point information display components.
            child = transform.GetChild(5).GetChild(1);
            _characterStatPointDisplays[0] = child.GetChild(0).GetChild(1).GetComponent<CharacterStatPointDisplay>();
            _characterStatPointDisplays[1] = child.GetChild(1).GetChild(1).GetComponent<CharacterStatPointDisplay>();
            _characterStatPointDisplays[2] = child.GetChild(1).GetChild(2).GetComponent<CharacterStatPointDisplay>();
            _characterStatPointDisplays[3] = child.GetChild(2).GetChild(1).GetComponent<CharacterStatPointDisplay>();
            _characterStatPointDisplays[4] = child.GetChild(2).GetChild(2).GetComponent<CharacterStatPointDisplay>();

            // Initialize information about stage progress display component.
            child = transform.GetChild(5).GetChild(2);
            _stageProgressDisplay = child.GetChild(2).GetComponent<StageProgressDisplay>();
        }

        public void DisplayClearState()
        {
            LogManager.LogProgress();
            
            _stageClearAnimation.Play();
        }

        public void DisplayCurrentEnemyCharacterCount(int count)
        {
            LogManager.LogProgress();
            
            _chapterInformationDisplays[0].SetText(count.ToString());
        }

        public void DisplayChapterProgressTime(string text)
        {
            _chapterInformationDisplays[1].SetText(text);
        }

        public void DisplayChapterScore(int score)
        {
            LogManager.LogProgress();
            
            _chapterInformationDisplays[2].SetText(score.ToString());
        }

        public void DisplayPlayerCharacterLifeCount(int count)
        {
            LogManager.LogProgress();
            
            _characterStatPointDisplays[0].SetText($"X{count:D2}");
        }

        public void DisplayPlayerCharacterDamagePoint(string text)
        {
            LogManager.LogProgress();
            
            _characterStatPointDisplays[1].SetText(text);
        }
        
        public void DisplayPlayerCharacterDefensePenetratePoint(string text)
        {
            LogManager.LogProgress();
            
            _characterStatPointDisplays[2].SetText(text);
        }
        
        public void DisplayPlayerCharacterDefensePoint(string text)
        {
            LogManager.LogProgress();
            
            _characterStatPointDisplays[3].SetText(text);
        }
        
        public void DisplayPlayerCharacterSpeedPoint(string text)
        {
            LogManager.LogProgress();
            
            _characterStatPointDisplays[4].SetText(text);
        }
        
        public SkillInformationDisplay[] SkillInformationDisplays { get; } = new SkillInformationDisplay[3];

        public InformationDisplayHandler InformationDisplayHandler { get; private set; }
    }
}