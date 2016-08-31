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
                    ImgUrl=@"UploadFiles/Photo/News/n3.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    OrderNo=1
                },
                new News
                {
                    Title="何谓【理念+算盘】的经营？",
                    Content="顾名思义，就是“理念”与“算盘”两手抓，把企业划分成一个个独立核算、自主经营的小单位，开展量化授权经营，激发员工的工作主动性、创造性，是以人才培养（与企业家理念一致）为基础，实现企业持续发展和高利润的经营方式。",
                    AddTime=DateTime.Parse("2015-6-6"),
                    ImgUrl=@"UploadFiles/Photo/News/n2.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=34",
                    OrderNo=1
                },
                new News
                {
                    Title="从被动管理迈向自主经营",
                    Content="A：企业错综复杂的管理问题，其根源不在管理，而在经营；B：唯有将“复杂的管理问题”上升到“经营的高度”才能实现简单、彻底解决；C：将员工从被动的“管理者、执行者”转化为主动思考和创造的“经营者”才能真正释放企业潜能。",
                    AddTime=DateTime.Parse("2015-6-1"),
                    ImgUrl=@"UploadFiles/Photo/News/n5.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=47",
                    OrderNo=1
                },
                new News
                {
                    Title="算盘：经营会计",
                    Content="会计是现代经营的中枢。与为了将企业的业绩以及财务状况正确地报告给外界的财务会计性质不同，经营会计是以支持企业提高效益而创立的系统经营量化工具。正确地把握企业活动的真实情况，对于经营的重要性不言而喻。如果会计资料不能够简单、真实地传达现在的经营状态，对于经营者就没有多少帮助。",
                    AddTime=DateTime.Parse("2015-6-4"),
                    ImgUrl=@"UploadFiles/Photo/News/n4.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=50",
                    OrderNo=1
                },
                new News
                {
                    Title="美博教育:“阿米巴+IT信息化",
                    Content="2015年10月，美博教育正式与道成咨询集团正式签订了【理念+算盘】“阿米巴辅导+IT信息化”项目，其中包括主要包括阿米巴经营落地辅导和AMB经营管理平台搭建两块内容。",
                    AddTime=DateTime.Parse("2016-6-14"),
                    ImgUrl=@"UploadFiles/Photo/News/n1.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=48",
                    OrderNo=1
                },
                new News
                {
                    Title="核心价值·解决企业根本问题",
                    Content="模块化的知识体系难以识别和解决经营的“根本问题”，且各模块之间难以衔接，很容易在经营过程中出现“类似问题反复发生”或“按下葫芦浮起瓢”的现象。",
                    AddTime=DateTime.Parse("2016-6-1"),
                    ImgUrl=@"UploadFiles/Photo/News/n6.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=page&a=index&id=51",
                    OrderNo=1
                },
                new News
                {
                    Title="《阿米巴经营实践指南》- 田和喜 ",
                    Content="本书是道成智聚在国内推出的第一本系统介绍阿米巴经营本土化实践的书籍。全书从实战角度将经营哲学、经营会计（实学）、阿米巴经营体制三者融会贯通，是中国企业正确理解、学习掌握稻盛和夫经营思想精髓，正确实践阿米巴经营的必备读物。",
                    AddTime=DateTime.Parse("2015-1-1"),
                    ImgUrl=@"UploadFiles/Photo/News/n7.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=50",
                    OrderNo=1
                },
                new News
                {
                    Title="华泰燃气-净利润提升200%",
                    Content="2015年10月项目正式启动，经过阿米巴系统内训、经营策略、核算系统、业绩分析评价与发表会等模块的构建辅导并实施；",
                    AddTime=DateTime.Parse("2016-1-31"),
                    ImgUrl=@"UploadFiles/Photo/News/n8.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=video&a=show&id=120",
                    OrderNo=0
                },
                new News
                {
                    Title="燕京啤酒自主经营模式推行访谈实录",
                    Content="2014年9月18日，道成智聚·阿米巴经营6载实践盛宴正在进行中，在课间歇息期间，笔者有幸与燕京啤酒(桂林漓泉)尹总进行自主经营推行成果经营交流专访，让我们一起来了解一下燕京漓泉的自主经营实践之路。",
                    AddTime=DateTime.Parse("2016-1-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n9.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=video&a=show&id=117",
                    OrderNo=0
                },
                new News
                {
                    Title="欧度控股阿米巴经营项目辅导纪实",
                    Content="欧度控股【理念+算盘】阿米巴经营模式咨询项目辅导进入第3次，已经取得显著效果。",
                    AddTime=DateTime.Parse("2016-2-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n10.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=video&a=show&id=116",
                    OrderNo=0
                },
                new News
                {
                    Title="阿米巴经营咨询项目助扬明五金造百年企业",
                    Content="2015年7月29日，道成咨询集团阿米巴经营资深经营顾问高然老师、刘峰老师走进扬明五金，启动【理念+算盘】阿米巴经营咨询项目。",
                    AddTime=DateTime.Parse("2015-8-2"),
                    ImgUrl=@"UploadFiles/Photo/News/n11.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=video&a=show&id=119",
                    OrderNo=0
                },
                new News
                {
                    Title="打造百年经典企业 赢在阿米巴经营策略",
                    Content="016年8月30日-9月1日，阿米巴经营中国落地开创者、道成咨询集团创始人田和喜老师为超级集团中高层管理人员讲授【理念+算盘】阿米巴经营。",
                    AddTime=DateTime.Parse("2016-8-31"),
                    ImgUrl=@"UploadFiles/Photo/News/n12.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1132",
                    OrderNo=0
                },
                new News
                {
                    Title="超级集团+【理念+算盘】自主经营",
                    Content="2016年8月26-27日，道成咨询集团资深经营顾问宗英涛老师走进无锡超级集团，为其基层管理人员讲解阿米巴经营的秘诀，获得与会人员的积极反响。",
                    AddTime=DateTime.Parse("2016-8-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n13.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1129",
                    OrderNo=0
                },
                new News
                {
                    Title="惠尔顿：【理念+算盘】阿米巴经营",
                    Content="2016年8月23-24日，阿米巴经营中国落地开创者、道成咨询集团创始人田和喜老师携道成咨询集团资深经营顾问刘峰、宗英涛老师组成项目小组再次来到宁波惠尔顿。",
                    AddTime=DateTime.Parse("2016-8-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n14.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1127",
                    OrderNo=0
                },
                new News
                {
                    Title="上海国药：“阿米巴+一体化服务”",
                    Content="2016年8月19日，道成咨询集团资深经营顾问宗英涛老师走进国药控股分销中心有限公司，为其中高层管理人员讲授阿米巴经营。",
                    AddTime=DateTime.Parse("2016-8-28"),
                    ImgUrl=@"UploadFiles/Photo/News/n15.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1122",
                    OrderNo=0
                },
                new News
                {
                    Title="道成咨询云集中国500强企业 铸商界巨子",
                    Content="当前，中国500强企业也逐渐关注到阿米巴经营经营模式，并携手阿米巴经营本土化领导者广州道成智聚，学习隐秘于其背后的【理念+算盘】经营真谛，为企业发展注入新活力。",
                    AddTime=DateTime.Parse("2016-2-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n16.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1001",
                    OrderNo=1
                },
                new News
                {
                    Title="中国500强大北农集团再次引入阿米巴经营",
                    Content="大北农集团是道成智聚的老朋友了，去年9月就曾邀请阿米巴资深经营顾问高老师前往企业做辅导，引起了强烈反响和高度认同。",
                    AddTime=DateTime.Parse("2016-1-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n17.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=301",
                    OrderNo=0
                },
                new News
                {
                    Title="经营实学•80期《阿米巴经营原理与推行实践》",
                    Content="2016年8月26-28日，【理念+算盘】经营实学•80期《阿米巴经营原理与推行实践》实操班在广州拉开帷幕。",
                    AddTime=DateTime.Parse("2016-9-1"),
                    ImgUrl=@"UploadFiles/Photo/News/n18.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1128",
                    OrderNo=0
                },
                new News
                {
                    Title="阿米巴经营(中国)研究院成立 田和喜荣任首届院长",
                    Content="2016年8月17日，经广东省民政厅审批许可，阿米巴经营（中国）研究院在广州正式成立并举行授牌仪式。【理念+算盘】经营实学创始人、阿米巴经营中国落地开创者、道成咨询集团创始人田和喜荣任首届院长。",
                    AddTime=DateTime.Parse("2016-8-20"),
                    ImgUrl=@"UploadFiles/Photo/News/n19.gif",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=show&id=1120",
                    OrderNo=1
                },
                new News
                {
                    Title="立高食品：推行5年 销售额从2.2亿突破7.3亿",
                    Content="2010年10月开始学习【理念+算盘】构建本企业的阿米巴经营模式，通过1年努力，企业实现了阿米巴经营的“SBU量化分权”和“Min-SBU量化分权”两个阶段。",
                    AddTime=DateTime.Parse("2016-7-30"),
                    ImgUrl=@"UploadFiles/Photo/News/n20.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=video&a=show&id=122",
                    OrderNo=0
                },
                new News
                {
                    Title="阿米巴经营原理与推行实践》课程回顾",
                    Content="道成咨询集团以“传播【理念+算盘】经营实学和经营智慧，强企兴邦，振兴中华！”为使命， 致力于帮助中国企业快速缩小与世界优秀企业在企业经营管理技术领域的差距。",
                    AddTime=DateTime.Parse("2016-9-3"),
                    ImgUrl=@"UploadFiles/Photo/News/n21.jpg",
                    Url="http://www.simchn.com/index.php?g=home&m=article&a=index&id=77",
                    OrderNo=1
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