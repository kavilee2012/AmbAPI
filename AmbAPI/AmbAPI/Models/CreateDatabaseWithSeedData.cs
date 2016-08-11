using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AmbAPI.Models
{
    public class CreateDatabaseWithSeedData<T> : CreateDatabaseIfNotExists<MyContext>  //DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            LoadSeed(context);
            base.Seed(context);
        }

        public void LoadSeed(MyContext context)
        {
            GetNews().ForEach(X => context.News.Add(X));
            GetReports().ForEach(X => context.AccountReport.Add(X));
            GetSbus().ForEach(X => context.SBU.Add(X));
        }

        #region 新增新闻
        private static List<News> GetNews()
        {
            var menus = new List<News> { 
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分。",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="何谓【理念+算盘】的经营？",
                    Content="顾名思义，就是“理念”与“算盘”两手抓，把企业划分成一个个独立核算、自主经营的小单位，开展量化授权经营，激发员工的工作主动性、创造性，是以人才培养（与企业家理念一致）为基础，实现企业持续发展和高利润的经营方式。",
                    AddTime=DateTime.Parse("2015-6-6"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=34",
                    IsTop=true
                },
                new News
                {
                    Title="从被动管理迈向自主经营",
                    Content="A：企业错综复杂的管理问题，其根源不在管理，而在经营；B：唯有将“复杂的管理问题”上升到“经营的高度”才能实现简单、彻底解决；C：将员工从被动的“管理者、执行者”转化为主动思考和创造的“经营者”才能真正释放企业潜能。",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=47",
                    IsTop=true
                },
                new News
                {
                    Title="算盘：经营会计",
                    Content="会计是现代经营的中枢。与为了将企业的业绩以及财务状况正确地报告给外界的财务会计性质不同，经营会计是以支持企业提高效益而创立的系统经营量化工具。正确地把握企业活动的真实情况，对于经营的重要性不言而喻。如果会计资料不能够简单、真实地传达现在的经营状态，对于经营者就没有多少帮助。",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                },
                new News
                {
                    Title="【理念+算盘】的起源与发展",
                    Content="1968年开始直至2009年，日本保持世界第2大经济体的地位长达41年之久，世界知名的跨国企业比比皆是。 不少研究者认为，二战后日本在一片废墟上以惊人的速度崛起，与儒家文化在日本的传播延续密不可分",
                    AddTime=DateTime.Parse("2015-6-1"),
                    Author="xxx",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    IsTop=true
                }
            };
            return menus;
        }
        #endregion

        #region 经营会计报表结构
        private static List<AccountReport> GetReports()
        {
            var reports = new List<AccountReport>{
                new AccountReport{
                    KmName="收入",
                    FatherID=0,
                    Level=1
                },
                new AccountReport{
                    KmName="支出",
                    FatherID=0,
                    Level=1
                },
                new AccountReport{
                    KmName="利润",
                    FatherID=0,
                    Level=1
                }
            };
            return reports;
        }
        #endregion

        #region SBU
        private static List<SBU> GetSbus()
        {
            var sbus = new List<SBU>{
                new SBU{
                    ID=1,
                    Name="AAA",
                    Remark="来源ERP财务部",
                    AddTime=DateTime.Now,
                    Header="aa"
                },
                new SBU{
                    ID=2,
                    Name="BBB",
                    Remark="来源ERP直销部",
                    AddTime=DateTime.Now,
                    Header="bb"
                },
                new SBU{
                    ID=3,
                    Name="CCC",
                    Remark="来源ERP客服部",
                    AddTime=DateTime.Now,
                    Header="cc"
                }
            };
            return sbus;
        }
        #endregion
    }
}