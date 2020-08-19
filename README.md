# A Simple Unity TextAVG Frame
on Unity 2018.4.17
Update: 2020-8-19

```
You can create a SIMPLE word adventure game(AVG) by writing text files in the format I set.
And this frame can do:
1. Read the text file and parse it into the corresponding object model according to the set syntax. 
2. After setting the UI component, you can play the corresponding content through the set syntax. 
3. Displays the character name and scrolls the dialogue, toggles the playback speed and sets the delay at a character. 
4. The gradual transition between the character vertical drawing and the background. 
5. Gradual switching between background music and character voice. 
6. Set the button to select the event and receive the event result. 
7. Free to pause, continue, and reopen the process. 
8. Customize the start and end events. 
9. Custom animation. 
10. Customize how resource files are loaded.
Rookie works, for reference only :)
Comments and suggestions are welcome.
My Station: http://114.55.103.20/
E-mail: 770291799@qq.com

您可以通过以我设置的格式编写文本文件来创建一个简单的文字冒险游戏(AVG)
这个框架可以做到以下几点：
1.读取文本文件，并根据设定的语法解析成相应的对象模型。
2.在设定好UI组件后，可以通过设定的语法播放相应内容。
3.显示角色名以及滚动播放对白，可切换播放速度以及设定在某字符处延时。
4.角色立绘和背景的渐变切换。
5.背景音乐和角色语音的渐变切换。
6.设定按钮选择事件，接收事件结果。
7.自由暂停，继续，重开流程。
8.自定义开始和结束事件。
9.自定义动画。
10.自定义资源文件的加载方式。
水平有限，仅供参考 :>
欢迎提出意见和建议

个人网站: http://114.55.103.20/
QQ: 770291799

Specific mode of use in Chinese:

Readme.txt
Duo1J AVG Frame Demo~

请在Hierarchy中任意物体上添加AVG Frame脚本

AVGFrame.cs-------------------
Image Url Prefix: 图像文件路径前缀， 在Resources文件夹中存放图像文件的前缀
Audio Url Prefix: 同上
TextAsset: 此AVGFrame中的演出脚本

UI Component-----
Canvas: 场景UI画布组件
Text: 对话显示Text组件
Name Text: 角色名称显示Text组件
Character Image: 角色立绘显示Image组件
Background Image: 背景图片显示Image组件
Character Voice: 角色语音Audio Source组件
Background Music: 背景音乐Audio Source组件

----------------------------------------------------------------------------------------------------------------
演出脚本书写格式：

具体参照 demo.txt

注释: #
脚本中的空行需要#占位

1.文本指令: T/角色名/对话文本/语音/延迟索引:延迟时间/.../ (不定长)
exp: T/Jack/Hello/Jack01.mp3/2:0.5/   (在播放到e时候延迟0.5s)
尽量不要连续延迟,如: T/Ketty/12345//2:0.5/3:0.5/4:0.5/ 可改成 => T/Ketty/12 3 45//2:0.5/4:0.5/6:0.5/

2.系统指令: C/角色img/img位置/x偏移/y偏移/背景img/背景audio/
x,y偏移默认为0，区分正负
img位置只能填入0 1 2,  0-靠左，1-居中，2-靠右
只有audio相关需带上文件后缀

3.选择按钮指令: B/事件名称/选项1/选项2/.../ (不定长)
exp: B/Dowhat/Study/Shop/

4.动画指令: A/动画类型/
动画类型不区分大小写
自带动画: 'ch_shake'角色晃动 'bk_shake'背景晃动
exp: A/ch_shake/
自定义动画请重写Duo1JAnimation接口并将实现类挂载在AVGFrame同一物体，参照InterfaceExample.cs

!!!所有指令以/结尾， 若某参数不填则需要//留出
exp: T/Mary/Goodbye!///  语音和延迟均不使用

!!!图片文件不加后缀，音频文件加后缀

interface----------------------------------------------------------------------------------------------------
自行实现了接口后将其挂载在AVGFrame同物体上即可
如果不写，则会分配一个默认实现

Duo1JAround接口-----------------------------------------
实现void After()和void Before()方法
Before()和After()在播放的开始和结束时候调用

Duo1JAnimation接口-----------------------------------------
实现void StartAnimation(string type)方法
type为 A/type/ 指令中的type

Duo1JAction接口--------------------------------------------
实现void GetButtonChoose(string eventTag, Choose choose)方法
eventTag为 B/event/choose1/choose2/.../指令中的event
Choose.index和Choose.text为选择的索引和内容

Duo1JLoader接口-------------------------------------
实现bool Analysis(out List<AVGModel> modelList, UnityEngine.TextAsset textAsset)方法
返回值为是否解析成功
解析textAsset成AVGModel对象，返回到modelList中

Duo1JInput接口--------------------------------------
自定义下一步输入

Specific use of mode in English:

Readme.txt. 
Duo1J AVG Frame Demo~. 

Please add AVG Frame script to any object in Hierarchy. 

AVGFrame.cs. 
Image Url Prefix: image file path prefix, which stores the image file prefix in the Resources folder. 
Audio Url Prefix: ditto. 
TextAsset: the performance script in this AVGFrame. 

UI Component-. 
Canvas: scene UI canvas components. 
Text: conversation display Text component. 
Name Text: role name display Text component. 
Character Image: role drawing display Image component. 
Background Image: background picture display Image component. 
Character Voice: role Voice Audio Source component. 
Background Music: background Music Audio Source component. 

---------------------------------------------------------------------------------
The script of the performance is written in the following format: 

For more information, please refer to demo.txt. 

Note: # 
Blank lines in the script require # placeholder. 

1. Text instruction: T/role name/dialogue text/voice audio/delay index:delay time/.../(variable length)
Exp: T/Jack/Hello/Jack01.mp3/2:0.5/ (delay 0.5s when playing to e). 
Try not to delay continuously, for example, T/Ketty/12345//2:0.5/3:0.5/4:0.5/ can be changed to = > T/Ketty/12 3 45//2:0.5/4:0.5/6:0.5/ 

2. System instruction: C/character img/img position/x offset/y offset/background img/background audio/ 
The default is 0, which distinguishes the positive from the negative. 
Img position can only be filled in 0 1 2, 0-left, 1-center, 2-right. 
Only audio-related files need to be suffixed. 

3. Select button instruction: B/event name/option 1/option 2/(variable length).
Exp: B/Dowhat/Study/Shop/

4. Animation instruction: a/Animation Type/
Animation types are not case sensitive. 
Comes with animation: 'ch_shake' character wobble' bk_shake' background wobble. 
Exp: A/ch_shake/
For custom animation, please override the Duo1JAnimation interface and mount the implementation class to the same AVGFrame object. Refer to InterfaceExample.cs. 

!!! All instructions end with /, and // is required if a parameter is left empty. 
Exp: T/Mary/Goodbye!/// voice and delay are not used. 

!!! Picture files are not suffixed, audio files are suffixed. 

Interface------------------------
After implementing the interface by yourself, you can mount it on the same object in AVGFrame. 
If you do not write, a default implementation is assigned. 

Duo1JAround interface------------------------
Implement void After () and void Before () methods. 
Before () and After () are called at the beginning and end of playback. 

Duo1JAnimation interface--. 
Implement the void StartAnimation (string type) method. 
Type is the type in the A/type/ instruction. 

Duo1JAction interface------------------------
Implement the void GetButtonChoose (string eventTag, Choose choose) method. 
EventTag is the event in the B/event/choose1/choose2/.../ instruction.
Choose.index and Choose.text are selected indexes and content. 

Duo1JLoader interface------------------------
Implement the bool Analysis (out List < AVGModel > modelList, UnityEngine.TextAsset textAsset) method. 
The return value is whether the resolution is successful. 
Parse textAsset into an AVGModel object and return it to modelList. 

Duo1JInput interface-------------------------
Customize the "go to next step" input

```
