﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuTraining.util
{
    public class ConfigHolder
    {   
        private static Dictionary<String, String> info;

        public static Dictionary<String, String> getInfo()
        {
            if (info == null)
            {
                info = new Dictionary<String, String>();
                init();
            }

            return info;
        }

        public static void init() 
        {
            // 视频页面信息
            info.Add("连、营抢救组的主要任务和救治原则.d", "");
            info.Add("连、营抢救组的主要任务和救治原则.f", "test.mp4");
            info.Add("分类.d", "");
            info.Add("分类.f", "");
            info.Add("后送.d", "");
            info.Add("后送.f", "");
            info.Add("分类标识.d", "");
            info.Add("分类标识.f", "");
            info.Add("处置顺序.d", "");
            info.Add("处置顺序.f", "");
            info.Add("现场救援工作的基本原则.d", "");
            info.Add("现场救援工作的基本原则.f", "");
            info.Add("现场急救的实施.d", "");
            info.Add("现场急救的实施.f", "");
            info.Add("现场救援主要机构、职责.d", "");
            info.Add("现场救援主要机构、职责.f", "");
            info.Add("现场医疗救援区域设置.d", "");
            info.Add("现场医疗救援区域设置.f", "");
            info.Add("现场（院前）评估.d", "");
            info.Add("现场（院前）评估.f", "");
            info.Add("处置顺序及标识.d", "");
            info.Add("处置顺序及标识.f", "");
            info.Add("生命体征检查.d", "");
            info.Add("生命体征检查.f", "");
            info.Add("伤势评估参考标准（军、地）.d", "");
            info.Add("伤势评估参考标准（军、地）.f", "");
            info.Add("拨打求助电话要求.d", "");
            info.Add("拨打求助电话要求.f", "");
            info.Add("手指掏出术.d", "");
            info.Add("手指掏出术.f", "");
            info.Add("立位腹部冲击法（海姆立克手法）.d", "");
            info.Add("立位腹部冲击法（海姆立克手法）.f", "");
            info.Add("拍背法：使用于清醒伤员.d", "");
            info.Add("拍背法：使用于清醒伤员.f", "");
            info.Add("舌后坠的控制.d", "");
            info.Add("舌后坠的控制.f", "");
            info.Add("悬吊固定上颌骨.d", "");
            info.Add("悬吊固定上颌骨.f", "");
            info.Add("环甲膜穿刺.d", "");
            info.Add("环甲膜穿刺.f", "");
            info.Add("气管插管的方法.d", "");
            info.Add("气管插管的方法.f", "");
            info.Add("昏迷伤（病）员有利于呼吸体位.d", "");
            info.Add("昏迷伤（病）员有利于呼吸体位.f", "");
            info.Add("口咽呼吸管通气法.d", "");
            info.Add("口咽呼吸管通气法.f", "");
            info.Add("判断、开放气道（A）.d", "");
            info.Add("判断、开放气道（A）.f", "");
            info.Add("口对口人工呼吸（B）.d", "");
            info.Add("口对口人工呼吸（B）.f", "");
            info.Add("胸外心脏按压（C）.d", "");
            info.Add("胸外心脏按压（C）.f", "");
            info.Add("心肺复苏（CPR）程序.d", "");
            info.Add("心肺复苏（CPR）程序.f", "");
            info.Add("判断出血.d", "");
            info.Add("判断出血.f", "");
            info.Add("加压包扎止血法.d", "");
            info.Add("加压包扎止血法.f", "");
            info.Add("颞动脉止血法.d", "");
            info.Add("颞动脉止血法.f", "");
            info.Add("面动脉止血法.d", "");
            info.Add("面动脉止血法.f", "");
            info.Add("颈动脉止血法.d", "");
            info.Add("颈动脉止血法.f", "");
            info.Add("锁骨下动脉止血法.d", "");
            info.Add("锁骨下动脉止血法.f", "");
            info.Add("肱动脉止血法.d", "");
            info.Add("肱动脉止血法.f", "");
            info.Add("尺、桡动脉止血法.d", "");
            info.Add("尺、桡动脉止血法.f", "");
            info.Add("股动脉止血法.d", "");
            info.Add("股动脉止血法.f", "");
            info.Add("足背动脉与胫后动脉止血法.d", "");
            info.Add("足背动脉与胫后动脉止血法.f", "");
            info.Add("指动脉止血法.d", "");
            info.Add("指动脉止血法.f", "");
            info.Add("填塞止血法（1种）.d", "");
            info.Add("填塞止血法（1种）.f", "");
            info.Add("充气止血带止血法.d", "");
            info.Add("充气止血带止血法.f", "");
            info.Add("橡皮止血带止血法.d", "");
            info.Add("橡皮止血带止血法.f", "");
            info.Add("绞棒止血法.d", "");
            info.Add("绞棒止血法.f", "");
            info.Add("卡式止血带止血法.d", "");
            info.Add("卡式止血带止血法.f", "卡式止血带止血法.mp4");
            info.Add("屈臂加压止血法.d", "");
            info.Add("屈臂加压止血法.f", "");
            info.Add("三角巾说明.d", "");
            info.Add("三角巾说明.f", "");
            info.Add("头顶部包扎法.d", "");
            info.Add("头顶部包扎法.f", "");
            info.Add("头部风帽式包扎法.d", "");
            info.Add("头部风帽式包扎法.f", "");
            info.Add("面具式包扎法.d", "");
            info.Add("面具式包扎法.f", "");
            info.Add("单侧面部包扎法.d", "");
            info.Add("单侧面部包扎法.f", "");
            info.Add("眼部包扎法（三角巾）.d", "");
            info.Add("眼部包扎法（三角巾）.f", "");
            info.Add("单耳或双耳包扎法.d", "");
            info.Add("单耳或双耳包扎法.f", "");
            info.Add("下颌带式包扎法.d", "");
            info.Add("下颌带式包扎法.f", "");
            info.Add("单肩燕尾式包扎法.d", "");
            info.Add("单肩燕尾式包扎法.f", "");
            info.Add("双肩燕尾式包扎法.d", "");
            info.Add("双肩燕尾式包扎法.f", "");
            info.Add("腋窝包扎法.d", "");
            info.Add("腋窝包扎法.f", "");
            info.Add("手三角巾包扎法.d", "");
            info.Add("手三角巾包扎法.f", "");
            info.Add("手“8”字包扎法.d", "");
            info.Add("手“8”字包扎法.f", "");
            info.Add("单侧手臂包扎法.d", "");
            info.Add("单侧手臂包扎法.f", "");
            info.Add("大悬臂带包扎法.d", "");
            info.Add("大悬臂带包扎法.f", "");
            info.Add("小悬臂带包扎法.d", "");
            info.Add("小悬臂带包扎法.f", "");
            info.Add("胸部包扎法（三角巾）.d", "");
            info.Add("胸部包扎法（三角巾）.f", "");
            info.Add("胸部燕尾式包扎法.d", "");
            info.Add("胸部燕尾式包扎法.f", "");
            info.Add("侧胸燕尾式包扎法.d", "");
            info.Add("侧胸燕尾式包扎法.f", "");
            info.Add("胸背部双三角巾包扎法.d", "");
            info.Add("胸背部双三角巾包扎法.f", "");
            info.Add("腹部兜式包扎法.d", "");
            info.Add("腹部兜式包扎法.f", "");
            info.Add("腹部燕尾式包扎法.d", "");
            info.Add("腹部燕尾式包扎法.f", "");
            info.Add("腹股沟与臀部包扎法.d", "");
            info.Add("腹股沟与臀部包扎法.f", "");
            info.Add("单侧臀部燕尾式包扎法.d", "");
            info.Add("单侧臀部燕尾式包扎法.f", "");
            info.Add("双侧臀部蝴蝶式包扎法.d", "");
            info.Add("双侧臀部蝴蝶式包扎法.f", "");
            info.Add("膝部三角巾包扎.d", "");
            info.Add("膝部三角巾包扎.f", "");
            info.Add("头部绷带包扎法.d", "");
            info.Add("头部绷带包扎法.f", "");
            info.Add("眼部包扎法（绷带）.d", "");
            info.Add("眼部包扎法（绷带）.f", "");
            info.Add("耳部包扎法.d", "");
            info.Add("耳部包扎法.f", "");
            info.Add("单肩包扎法.d", "");
            info.Add("单肩包扎法.f", "");
            info.Add("胸部包扎法（绷带）.d", "");
            info.Add("胸部包扎法（绷带）.f", "");
            info.Add("单侧腹股沟包扎法.d", "");
            info.Add("单侧腹股沟包扎法.f", "");
            info.Add("手部露指尖包扎法.d", "");
            info.Add("手部露指尖包扎法.f", "");
            info.Add("单指包扎法.d", "");
            info.Add("单指包扎法.f", "");
            info.Add("肘部包扎法.d", "");
            info.Add("肘部包扎法.f", "");
            info.Add("足跟部包扎法.d", "");
            info.Add("足跟部包扎法.f", "");
            info.Add("“T”字型夹板固定法.d", "");
            info.Add("“T”字型夹板固定法.f", "");
            info.Add("锁骨骨折三角巾固定法.d", "");
            info.Add("锁骨骨折三角巾固定法.f", "");
            info.Add("肱骨骨折夹板固定法.d", "");
            info.Add("肱骨骨折夹板固定法.f", "");
            info.Add("肱骨骨折三角巾固定法.d", "");
            info.Add("肱骨骨折三角巾固定法.f", "");
            info.Add("前臂骨折夹板固定法.d", "");
            info.Add("前臂骨折夹板固定法.f", "");
            info.Add("前臂骨折三角巾固定法.d", "");
            info.Add("前臂骨折三角巾固定法.f", "");
            info.Add("股骨骨折夹板固定法.d", "");
            info.Add("股骨骨折夹板固定法.f", "");
            info.Add("股骨骨折键肢固定法.d", "");
            info.Add("股骨骨折键肢固定法.f", "");
            info.Add("小腿骨折夹板固定法.d", "");
            info.Add("小腿骨折夹板固定法.f", "");
            info.Add("小腿骨折键肢固定法.d", "");
            info.Add("小腿骨折键肢固定法.f", "");
            info.Add("拖动法.d", "");
            info.Add("拖动法.f", "");
            info.Add("搀扶伤（病）员.d", "");
            info.Add("搀扶伤（病）员.f", "");
            info.Add("扛法.d", "");
            info.Add("扛法.f", "");
            info.Add("背法.d", "");
            info.Add("背法.f", "");
            info.Add("抱法.d", "");
            info.Add("抱法.f", "");
            info.Add("单人匍匐搬运法.d", "");
            info.Add("单人匍匐搬运法.f", "");
            info.Add("单人侧姿搬运法.d", "");
            info.Add("单人侧姿搬运法.f", "");
            info.Add("四手“扶椅”法.d", "");
            info.Add("四手“扶椅”法.f", "");
            info.Add("依托式.d", "");
            info.Add("依托式.f", "");
            info.Add("拉车式.d", "");
            info.Add("拉车式.f", "");
            info.Add("双人同步搬运法.d", "");
            info.Add("双人同步搬运法.f", "");
            info.Add("双人交互式搬运法.d", "");
            info.Add("双人交互式搬运法.f", "");
            info.Add("一般伤员上担架法.d", "");
            info.Add("一般伤员上担架法.f", "");
            info.Add("脊柱脊髓伤伤（病）员搬运法.d", "");
            info.Add("脊柱脊髓伤伤（病）员搬运法.f", "");
            info.Add("颈椎伤伤（病）员搬运法.d", "");
            info.Add("颈椎伤伤（病）员搬运法.f", "");
            info.Add("担架拖拉式双人匍匐搬运法.d", "");
            info.Add("担架拖拉式双人匍匐搬运法.f", "");
            info.Add("注意事项.d", "");
            info.Add("注意事项.f", "");
            info.Add("包扎物选材及使用.d", "");
            info.Add("包扎物选材及使用.f", "");
            info.Add("衣物固定包扎法.d", "");
            info.Add("衣物固定包扎法.f", "");
            info.Add("简易颈托制作及使用.d", "");
            info.Add("简易颈托制作及使用.f", "");
            info.Add("简易担架制作及使用.d", "");
            info.Add("简易担架制作及使用.f", "");
            info.Add("头皮撕裂伤.d", "");
            info.Add("头皮撕裂伤.f", "");
            info.Add("脑脊液外漏.d", "");
            info.Add("脑脊液外漏.f", "");
            info.Add("开放性颅脑损伤.d", "");
            info.Add("开放性颅脑损伤.f", "");
            info.Add("胸部浅表伤口处理.d", "");
            info.Add("胸部浅表伤口处理.f", "");
            info.Add("张力性气胸.d", "");
            info.Add("张力性气胸.f", "");
            info.Add("开放性气胸.d", "");
            info.Add("开放性气胸.f", "");
            info.Add("连枷胸.d", "");
            info.Add("连枷胸.f", "");
            info.Add("腹部外伤.d", "");
            info.Add("腹部外伤.f", "");
            info.Add("脊柱、脊髓损伤.d", "");
            info.Add("脊柱、脊髓损伤.f", "");
            info.Add("开放性骨折.d", "");
            info.Add("开放性骨折.f", "");
            info.Add("肢体断离.d", "");
            info.Add("肢体断离.f", "");
            info.Add("骨盆和会阴部外伤.d", "");
            info.Add("骨盆和会阴部外伤.f", "");
            info.Add("颌、面、颈部外伤.d", "");
            info.Add("颌、面、颈部外伤.f", "");
            info.Add("眼部伤.d", "");
            info.Add("眼部伤.f", "");
            info.Add("眼异物.d", "");
            info.Add("眼异物.f", "");
            info.Add("眼睛化学药剂损伤.d", "");
            info.Add("眼睛化学药剂损伤.f", "");
            info.Add("鼻出血.d", "");
            info.Add("鼻出血.f", "");
            info.Add("耳部外伤.d", "");
            info.Add("耳部外伤.f", "");
            info.Add("耳部异物.d", "");
            info.Add("耳部异物.f", "");
            info.Add("脑卒中.d", "");
            info.Add("脑卒中.f", "");
            info.Add("癫痫.d", "");
            info.Add("癫痫.f", "");
            info.Add("气管阻塞.d", "");
            info.Add("气管阻塞.f", "");
            info.Add("急性呼吸衰竭.d", "");
            info.Add("急性呼吸衰竭.f", "");
            info.Add("心绞痛.d", "");
            info.Add("心绞痛.f", "");
            info.Add("心肌梗死.d", "");
            info.Add("心肌梗死.f", "");
            info.Add("战伤休克.d", "");
            info.Add("战伤休克.f", "");
            info.Add("放射性损伤.d", "");
            info.Add("放射性损伤.f", "");
            info.Add("化学毒剂损伤.d", "");
            info.Add("化学毒剂损伤.f", "");
            info.Add("推进剂损伤.d", "");
            info.Add("推进剂损伤.f", "");
            info.Add("食物中毒.d", "");
            info.Add("食物中毒.f", "");
            info.Add("农药中毒.d", "");
            info.Add("农药中毒.f", "");
            info.Add("一氧化碳（煤气）中毒.d", "");
            info.Add("一氧化碳（煤气）中毒.f", "");
            info.Add("中暑.d", "");
            info.Add("中暑.f", "");
            info.Add("烧伤.d", "");
            info.Add("烧伤.f", "");
            info.Add("冻伤.d", "");
            info.Add("冻伤.f", "");
            info.Add("晕车晕船.d", "");
            info.Add("晕车晕船.f", "");
            info.Add("毒蛇咬伤.d", "");
            info.Add("毒蛇咬伤.f", "");
            info.Add("挤压伤.d", "");
            info.Add("挤压伤.f", "");
            info.Add("冲击伤.d", "");
            info.Add("冲击伤.f", "");
            info.Add("拉伤、扭伤.d", "");
            info.Add("拉伤、扭伤.f", "");
            info.Add("骨折.d", "");
            info.Add("骨折.f", "");
            info.Add("肌肉痉挛.d", "");
            info.Add("肌肉痉挛.f", "");
            info.Add("电击伤.d", "");
            info.Add("电击伤.f", "");
            info.Add("淹溺.d", "");
            info.Add("淹溺.f", "");
            info.Add("地震.d", "");
            info.Add("地震.f", "");
            info.Add("洪水爆发.d", "");
            info.Add("洪水爆发.f", "");
            info.Add("交通事故现场防护及处理.d", "");
            info.Add("交通事故现场防护及处理.f", "");
            info.Add("火灾现场防护及处理.d", "");
            info.Add("火灾现场防护及处理.f", "");

            // 描述页信息
            info.Add("突发事件现场医疗救援的组织与实施.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("通气.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("基础生命支持.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("止血.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("指压止血法.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("止血带止血法.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("包扎.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("绷带包扎法.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("固定.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("搬运.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("担架搬运法.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("暴露伤口的方法.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
            info.Add("常见中毒急救.d", "这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页这是文字说明页");
        }
    }
}