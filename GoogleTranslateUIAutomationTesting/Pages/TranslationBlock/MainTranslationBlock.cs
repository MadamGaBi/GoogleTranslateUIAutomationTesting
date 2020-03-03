using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateUIAutomationTesting.Pages.TranslationBlock
{
    public class MainTranslationBlock : Page
    {
        public SourceContainer SourceContainer => GetPage<SourceContainer>();
        public LanguageBar LanguageBar => GetPage<LanguageBar>();
        public ResultContainer ResultContainer => GetPage<ResultContainer>();
    }
}

