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

        public static void LoadSeed(MyContext context)
        {
            GetNews().ForEach(X => context.News.Add(X));
            GetReports().ForEach(X => context.Reports.Add(X));
            GetSbus().ForEach(X => context.SBU.Add(X));
            GetUsers().ForEach(X => context.User.Add(X));
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
        private static List<Report> GetReports()
        {
            var reports = new List<Report>{
                new Report{
                    Code="100",
                    FatherCode="0",
                    Level=0,
                    Order=100,
                    Name="销售额",
                    Remark=""
                },
                new Report{
                    Code="200",
                    FatherCode="0",
                    Level=0,
                    Order=200,
                    Name="变动费",
                    Remark=""
                },
                new Report{
                    Code="300",
                    FatherCode="0",
                    Level=0,
                    Order=300,
                    Name="边界利益",
                    Remark=""
                },
                new Report{
                    Code="400",
                    FatherCode="0",
                    Level=0,
                    Order=400,
                    Name="边界利益率",
                    Remark=""
                },
                new Report{
                    Code="500",
                    FatherCode="0",
                    Level=0,
                    Order=500,
                    Name="固定费用",
                    Remark=""
                },
                new Report{
                    Code="600",
                    FatherCode="0",
                    Level=0,
                    Order=600,
                    Name="经营利益",
                    Remark=""
                },
                new Report{
                    Code="700",
                    FatherCode="0",
                    Level=0,
                    Order=700,
                    Name="经营利益率",
                    Remark=""
                },

                new Report{
                    Code="101",
                    FatherCode="100",
                    Level=1,
                    Order=1,
                    Name="主营业务收入",
                    Remark=""
                },
                new Report{
                    Code="102",
                    FatherCode="100",
                    Level=1,
                    Order=2,
                    Name="其它业务收入",
                    Remark=""
                },
                new Report{
                    Code="103",
                    FatherCode="100",
                    Level=1,
                    Order=3,
                    Name="非业务收入",
                    Remark=""
                },

                new Report{
                    Code="201",
                    FatherCode="200",
                    Level=1,
                    Order=1,
                    Name="生产成本",
                    Remark=""
                },
                new Report{
                    Code="202",
                    FatherCode="200",
                    Level=1,
                    Order=2,
                    Name="销售成本",
                    Remark=""
                },
                new Report{
                    Code="203",
                    FatherCode="200",
                    Level=1,
                    Order=3,
                    Name="研发成本",
                    Remark=""
                },
                new Report{
                    Code="204",
                    FatherCode="200",
                    Level=1,
                    Order=4,
                    Name="其它变动费",
                    Remark=""
                },
                new Report{
                    Code="501",
                    FatherCode="500",
                    Level=1,
                    Order=1,
                    Name="员工工资",
                    Remark=""
                },
                new Report{
                    Code="502",
                    FatherCode="500",
                    Level=1,
                    Order=2,
                    Name="办公费用",
                    Remark=""
                },
                new Report{
                    Code="503",
                    FatherCode="500",
                    Level=1,
                    Order=3,
                    Name="场地费用",
                    Remark=""
                },
                new Report{
                    Code="504",
                    FatherCode="500",
                    Level=1,
                    Order=4,
                    Name="其它固定费用",
                    Remark=""
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
                    Code="100",
                    FatherCode="0",
                    Level=0,
                    Order=100,
                    Name="采购事业部",
                    Remark="来源ERP采购部",
                    Header="张丽",
                    MemberCount=12
                },
                new SBU{
                    Code="200",
                    FatherCode="0",
                    Level=0,
                    Order=200,
                    Name="生产事业部",
                    Remark="来源ERP生产部",
                    Header="王华春",
                    MemberCount=338
                },
                new SBU{
                    Code="300",
                    FatherCode="0",
                    Level=0,
                    Order=300,
                    Name="装配事业部",
                    Remark="来源ERP装配部",
                    Header="李玉强",
                    MemberCount=156
                },
                new SBU{
                    Code="400",
                    FatherCode="0",
                    Level=0,
                    Order=300,
                    Name="物流事业部",
                    Remark="来源ERP物流部",
                    Header="李子华",
                    MemberCount=53
                },
                new SBU{
                    Code="500",
                    FatherCode="0",
                    Level=0,
                    Order=500,
                    Name="销售事业部",
                    Remark="来源ERP销售部",
                    Header="李子华",
                    MemberCount=26
                },
                new SBU{
                    Code="600",
                    FatherCode="0",
                    Level=0,
                    Order=600,
                    Name="行政事业部",
                    Remark="来源ERP行政部",
                    Header="张亮",
                    MemberCount=32
                },
                new SBU{
                    Code="700",
                    FatherCode="0",
                    Level=0,
                    Order=700,
                    Name="财务事业部",
                    Remark="来源ERP财务部",
                    Header="马蓉春",
                    MemberCount=15
                },

                new SBU{
                    Code="201",
                    FatherCode="200",
                    Level=1,
                    Order=1,
                    Name="原材料加工事业部",
                    Remark="来源ERP生产部",
                    Header="李响",
                    MemberCount=22
                },
                new SBU{
                    Code="202",
                    FatherCode="200",
                    Level=1,
                    Order=2,
                    Name="质检事业部",
                    Remark="来源ERP生产部",
                    Header="崔霞",
                    MemberCount=5
                }
            };
            return sbus;
        }
        #endregion

        #region User
        private static List<User> GetUsers()
        {
            var list = new List<User>{
                new User{
                    UserCode="admin",
                    UserName="系统管理员",
                    Password="1",
                    Mobile="15876500757",
                    Sex=true
                },
                new User{
                    UserCode="lz",
                    UserName="李煜辰",
                    Password="1",
                    Mobile="15876500757",
                    Sex=false
                }
            };
            return list;
        }
        #endregion
    }
}