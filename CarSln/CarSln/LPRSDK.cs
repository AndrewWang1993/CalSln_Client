using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CarSln
{
    /*******************************************************************
函数说明:设备信息回调函数
参数说明：
pUserData 用户设置回调函数传入的用户数据
pDeviceInfo 见DeviceInfo结构体定义
**********************************************************************/
public delegate void DeviceInfoCallback(IntPtr pUserData, ref LPRSDK.DeviceInfo pDeviceInfo);

/*******************************************************************
函数说明:设备信息回调函数
参数说明：
pUserData 用户设置回调函数传入的用户数据
pStatus 见DeviceStatus结构体定义
**********************************************************************/
public delegate void DeviceStatusCallback(IntPtr pUserData, ref LPRSDK.DeviceStatus pStatus);

/*******************************************************************
函数说明:抓拍数据回调函数
参数说明：
pUserData 用户设置回调函数传入的用户数据
pData 见VehicleData结构体定义
**********************************************************************/
public delegate void VehicleDataCallback(IntPtr pUserData, ref LPRSDK.VehicleData pData);




/*******************************************************************
函数说明:实时JPG流回调函数
参数说明：
pUserData 用户设置回调函数传入的用户数据
pJPGData见JPGData结构体定义
**********************************************************************/
public delegate void JPGStreamCallBack(IntPtr pUserData, ref LPRSDK.JPGData pJPGData);

    public class LPRSDK
    {
        public const int INVALID_HANLE = 0;	//无效句柄
        public const int IP_MAX_LEN	= 16;	//IP地址字符串最大长度
        public const int MACADDR_LEN =	6;	//MAC地址
        public const int VERSION_LEN = 255;	//版本长度
        public const int MAX_PLATE_LEN = 16;	//车牌号码长度
        public const int MAX_TIME_LEN =	8;	//时间长度
        public const int AUTHORINFO_LEN = 100;	//授权相关信息长度
        public const int SERIALNO_LEN = 20;	//序列号长度
        public const int FEEKMSG_MAX_LEN = 100;	//反馈描述信息长度

        //函数返回值
        public enum FEEKBACK_TYPE: int
        {
	        RESULT_OK = 0,//执行成功
	        INIT_SUCCESS = 1,//已经初始化
	        NO_INIT = 2,   //未初始化
	        PARAMS_ERROR = 3,//参数不正确
	        SOCKET_NULL = 4,//SOCKET句柄为NULL
	        THREAD_FAIL = 5,//线程失败
	        CREATE_FAIL = 6, //生成命令失败
	        SEND_FAIL = 7,//发送命令失败
	        NO_FIND_DEVICE = 8,//没有发现设备
	        DEVICE_OPENED = 9,//设备已经打开
	        DEVICE_DISCONNECT = 10,//和设备的连接断开
	        CONTORL_NOCONNECTION = 11,//控制端口未连接
	        NO_RECEIVED_DATA = 12,//阻塞触发没有收到数据
	        OTHER_ERROR = 100,//其他错误
	        TIME_OUT = 209//函数执行超时
        }

        //设备状态
        public enum DEVICE_STATUS:int
        {
	        CONNECT_SUCCESS = 0,//连接成功
	        CREATE_ERROR = 1,//生成句柄错误
	        CONNECT_ERROR = 2,//连接错误
	        ABNORMALNET_ERROR = 3,//网络异常错误
            DEVICE_RESET = 4//设备复位

        } 

        //车牌颜色
        public enum  PLATE_COLOR:int
        {
	        NON_PLATE = 0,//未知车牌颜色
	        BLUE_COLOR,//蓝色
	        WHITE_COLOR,//白色
	        BLACK_COLOR,//黑色
	        YELLOW_COLOR//黄色
        } 

          public enum USER_TYPE : int
        {
             NORMAL_USER  = 0,// 正常用户
	         UNKNOWN_USER = 1//未授权用户
        }

          public enum DEVICE_TRIGGERMODE : int
        {
            UNKNOWN_TRIGGER_MODE = 0,//未知
	        VIDEO_TRIGGER_MODE = 1,//视频
	        LINE_TRIGGER_MODE = 2,//线圈
	        SOFT_TRIGGER_MODE//模拟
        }

        //快门值
        public enum SHUTTER_PARAMS:int
        {
	        SHUTTER_50 = 0,//1/50
	        SHUTTER_75,//1/75
	        SHUTTER_100,//1/100
	        SHUTTER_120,//1/120
	        SHUTTER_150,//1/150
	        SHUTTER_215 = 0,//1/215
	        SHUTTER_300,//1/300
	        SHUTTER_425 = 0,//1/425
	        SHUTTER_600,//1/600
	        SHUTTER_1000,//1/1000
	        SHUTTER_1250,//1/1250
	        SHUTTER_1750,//1/1750	
	        SHUTTER_2500,//1/2500
	        SHUTTER_3500,//1/3500
	        SHUTTER_6000,//1/6000
	        SHUTTER_10000 = 0//1/10000
        }

        //网络参数
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct NetParams
        {

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
            public string ucDeviceIP;//设备IP
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
            public string ucMaskIP;//掩码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
            public string ucGateIP;//网关

        }


        //设备基本信息
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct DeviceInfo
        {
            public NetParams DeviceNetInfo;//设备网络参数
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN)]
            public byte[] ucMAC;//MAC地址
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VERSION_LEN)]
            public string ucDeviceVersion;//设备版本信息
            public byte ucConnectNum;//用户连接数

        }
        //设备状态
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
            public struct DeviceStatus
            {
	            public IntPtr pHandle;//设备句柄
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
                public string ucDeviceIP;//设备IP
	            DEVICE_STATUS status;//设备状态

            }
        //输出内容
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct OutputContent
        {
            public bool bOutputBigImage;//是否输出大图
            public bool bOutputCIFImage;//是否输出CIF图
            public bool bOutputPlateImage;//是否输出车牌图
        }


       


        //抓拍数据
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct VehicleData
        {
            public IntPtr pDeviceHandle;//设备句柄
            public UInt16 usSerialNO;//序列号
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
            public string ucDeviceIP;//设备IP
            public UInt32 ui32DeviceID;//设备ID
          
            public USER_TYPE ui32UserType;							//表示用户类型:0 正常用户，1 未授权用户，其他值保留
	         public UInt32 ui32Brightness;						//亮度值
	        public DEVICE_TRIGGERMODE triggermode;						//触发类型:1 视频 2 线圈 3 模拟 0 未知 ，其他值保留
	        
             [MarshalAs(UnmanagedType.ByValArray, SizeConst = VERSION_LEN)]
            public byte[] ai8UserDefineInfo;


            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_TIME_LEN)]
            public byte[] ucTime;//时间，年（减掉后的年份）、月、日、时、分、秒、毫秒（占两个字节）
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PLATE_LEN)]
            public string ucPlate;//车牌号码
            public PLATE_COLOR PlateColor;//车牌颜色

            public IntPtr pucBigImage;//抓拍大图数据
            public UInt32 uiBigImageLen;//抓拍大图数据长度
            public UInt16 usBigImageWidth;//抓拍大图宽度
            public UInt16 usBigImageHeight;//抓拍大图高度

            public IntPtr pucCIFImage;//抓拍CIF图数据
            public UInt32 uiCIFImageLen;//抓拍CIF图数据长度
            public UInt16 usCIFImageWidth;//抓拍CIF图宽度
            public UInt16 usCIFImageHeight;//抓拍CIF图高度

            public IntPtr pucPlateImage;//抓拍车牌图数据
            public UInt32 uiPlateImageLen;//抓拍车牌图数据长度
            public UInt16 usPlateImageWidth;//抓拍车牌图宽度
            public UInt16 usPlateImageHeight;//抓拍车牌图高度
        }

        //实时JPG流
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct JPGData
        {
            public IntPtr pDeviceHandle;//设备句柄
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = IP_MAX_LEN)]
            public string ucDeviceIP;//设备IP
            public IntPtr pucImage;//一帧实时JPG流数据
            public UInt32 uiImageLen;// 一帧实时JPG流数据长度
            public UInt16 usImageWidth;// 一帧实时JPG流宽度
            public UInt16 usImageHeight;// 一帧实时JPG流高度
        }

        //授权信息

        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct AuthorInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AUTHORINFO_LEN)]
            public string ucAuthorCode;//授权码
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AUTHORINFO_LEN)]
            public string ucDeviceCode;//机器码
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_TIME_LEN)]
            public byte[] ucDate;//授权时间年（减掉后的年份）、月、日

        }

        //设备版本信息
        [StructLayout(LayoutKind.Sequential, Pack = 0, CharSet = CharSet.Ansi)]
        public struct VersionInfo
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VERSION_LEN)]
            public string ucDspVer;//DSP
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VERSION_LEN)]
            public string ucEPLD;//单片机版本
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VERSION_LEN)]
            public string ucOCR;//识别库版本

        }


        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_IsWriteLog(bool bWriteLog);
        函数名称: LPR_IsWriteLog
		          函数说明：是否记录动态库日志。日志文件自动生成在调用程序所在目录下，自动建立LPRLog文件夹，然后日志名称以时间命名，如：“20110101.log”
		          参数说明：
		          bWriteLog true记录日志，false不记录日志
		          返回值：
		          RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32 LPR_IsWriteLog(bool bWriteLog);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_GetErrorMsg(FEEKBACK_TYPE  FeekCode,char *pchErrMsg);
        函数名称: LPR_GetErrorMsg
        函数说明：获取反馈值对应的文字描述 
        参数说明：
        FeekCode反馈码，即接口函数返回值
        pchErrMsg 反馈代码对应的文字描述，分配空间大小为FEEKMSG_MAX_LEN
        返回值：
        RESULT_OK表示成功，否则返回错误代码

        **********************************************************************/
        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_GetErrorMsg(FEEKBACK_TYPE  FeekCode,StringBuilder pchErrMsg);


        /*******************************************************************
函数实体：unsigned int WINAPI LPR_Init(HWND hWnd,DeviceInfoCallback fucDeviceInfo,DeviceStatusCallback fucStatus,VehicleDataCallback fucVehicleData,JPGStreamCallBack fucJPGStream)  
函数名称: LPR_Init
函数说明：设置回调函数
参数说明：
hWnd   如此值为NULL，则回调函数在动态库所建立线程中响应；反之，在该句柄所在线程响应
pUserData 用户数据，在回调函数响应时传出
fucDeviceInfo 设备信息回调函数，见DeviceInfoCallback函数定义
fucStatus 设备状态回调函数，见DeviceStatusCallback定义
fucVehicleData 抓拍数据回调函数，见VehicleDataCallback函数定义
fucJPGStream  实时JPG流回调函数，见JPGStreamCallBack函数定义
返回值：
RESULT_OK表示成功，否则返回错误代码

**********************************************************************/
         [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "LPR_Init", SetLastError = true)]
        public static extern UInt32 LPR_Init(IntPtr hWnd, IntPtr pUserData, DeviceInfoCallback fucDeviceInfo, DeviceStatusCallback fucDeviceStatus,VehicleDataCallback fucVehicleData, JPGStreamCallBack fucJPGStream);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_Quit ()  
        函数名称: LPR_Quit
	          函数说明：释放动态库所有资源
	          参数说明：

	          返回值：
	          RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/

            [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
            public static extern UInt32  LPR_Quit();

            /*******************************************************************
            函数实体：unsigned int WINAPI LPR_ScanDevice();
            函数名称：HWTC_ ScanDevice
            函数说明：通过UDP命令，查找同一网段IP对应的设备
            返回值：
            RESULT_OK表示成功，否则返回错误代码
            备注：执行该函数后，如有扫描到设备，会立即响应设备信息回调函数


            **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_ScanDevice();

            /*******************************************************************
            函数实体：unsigned int WINAPI LPR_SetNetParams(PDEVICEHANDLE pHandle,NetParams OldParams,NetParams NewParams);
            函数名称: LPR _ConnectCamera
		              函数说明：网络参数设置
		              参数说明：pHandle，如果是UDP方式设置，则该参数是0；反之TCP时，指通过LPR _ConnectCamera获取
		              OldParams 设备原始网络参数，UDP设置时，需要
		              NewParams 设备新设置的参数
		              返回值：
		              返回值是RESULT_OK表示成功，否则返回错误代码
            **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32 LPR_SetNetParams(IntPtr pHandle, ref NetParams pOldParams, ref NetParams pNewParams);


            /*******************************************************************
            函数实体：unsigned int WINAPI LPR_ControlContent(OutputContent *pContent);
            函数名称: LPR_ControlContent
		              函数说明：控制传输内容
		              参数说明：
			            pContent 见OutputContent结构体定义
		              返回值：
		              返回值是RESULT_OK表示成功，否则返回错误代码
            **********************************************************************/

         [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_ControlContent(ref OutputContent pContent);


        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_ConnectCamera(char *pchDeviceIP, PDEVICEHANDLE *pHandle);
        函数名称: LPR _ConnectCamera
        函数说明：打开指定IP设备的连接
        参数说明：pchDeviceIP待连接的设备IP地址
			        pHandle执行成功后，返回设备句柄；否则为INVALID_HANLE
        返回值：
				        返回值是RESULT_OK表示成功，否则返回错误代码

        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_ConnectCamera(StringBuilder pchDeviceIP, ref IntPtr pHandle);


        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _DisconnectCamera(PDEVICEHANDLE pHandle);
        函数名称: LPR _DisconnectCamera
        函数说明：断开指定设备的连接
        参数说明：
        pHandle 设备句柄，通过LPR _ConnectCamera获取
        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码


        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_DisconnectCamera(IntPtr pHandle);

            /*******************************************************************
            函数实体：unsigned int WINAPI LPR _Capture(PDEVICEHANDLE pHandle)
            函数名称：LPR _ Capture
            函数说明：强制抓拍，向设备发送抓拍命令，设备抓拍图像和采集信息，并上传。该函数只保证参数下发成功后立即返回，不考虑设备是否执行该命令
            参数说明:
            pHandle相机句柄，由LPR _ConnectCamera获取
            返回值：
            返回值是RESULT_OK表示成功，否则返回错误代码
            **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_Capture(IntPtr pHandle);

            /*******************************************************************
            函数实体：unsigned int WINAPI LPR_CaptureEx(PDEVICEHANDLE pHandle,unsigned int nTimeout)
            函数名称：LPR _ CaptureEx
            函数说明：强制抓拍，向设备发送抓拍命令，设备抓拍图像和采集信息，并上传。该函数下发命令后，等待设备响应，直到收到设备传出的信息或者超时时间到，才返回。
            参数说明:
            pHandle相机句柄，由LPR _ConnectCamera获取
            nTimeout 阻塞超时时间，以ms为单位
            返回值：
            返回值是RESULT_OK表示成功，否则返回错误代码

            **********************************************************************/
        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_CaptureEx(IntPtr pHandle,UInt32 nTimeout);

            /*******************************************************************
            函数实体：unsigned int WINAPI LPR_CheckStatus(PDEVICEHANDLE pHandle , DEVICE_STATUS *pConnStatus)
		            函数名称：LPR _CheckStatus
		            函数说明：检测状态
		            参数说明:
            pHandle相机句柄，由LPR _ConnectCamera获取
				            pConnStatus：状态标记，见DEVICE _STATUS枚举
		            返回值：
		            返回值是RESULT_OK表示成功，否则返回错误代码


            **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_CheckStatus(IntPtr pHandle , ref DEVICE_STATUS pConnStatus);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _AdjustTime(PDEVICEHANDLE pHandle, unsigned __int64 dwTimeMs = 0)
		        函数名称：LPR _AdjustTime
        函数说明：给设备校时
		        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        时间值，(1900-1-1 0:0:0以来的毫秒数)，64位整数；默认为0，当为0时，直接获取当前系统时间，进行校时
		        返回值：
		        返回值是RESULT_OK表示成功，否则返回错误代码



        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_AdjustTime(IntPtr pHandle, UInt64 dwTimeMs);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_NTPEnable (PDEVICEHANDLE pHandle,bool bNTP,char *pchNTPSeverIP)
        函数名称：LPR_NTPEnable
        函数说明：是否启用NTP校时，如果启用NTP校时，则LPR_AdjustTime函数执行无效
        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        bNTP  true 表示启用；false表示不启用
        pchNTPSeverIP 如启用，则需要设置NTP服务器的IP地址
        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/
        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_NTPEnable (IntPtr pHandle,bool bNTP,StringBuilder pchNTPSeverIP);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR_JPGStreamEnable (PDEVICEHANDLE pHandle,bool bEnable)
        函数名称：LPR_ JPGStreamEnable
        函数说明：是否对应设备接收实时JPG流 ，
        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        bEnable true 表示启用；false表示不启用

        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_JPGStreamEnable (IntPtr pHandle,bool bEnable);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _GetAllVersion(PDEVICEHANDLE pHandle , VersionInfo *pVerInfo)
		        函数名称：LPR _ GetAllVersion
		        函数说明：获取设备所有版本信息
		        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
				        pVerInfo：设备详细版本信息，见VersionInfo定义
		        返回值：
		        返回值是RESULT_OK表示成功，否则返回错误代码

        **********************************************************************/


        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_GetAllVersion(IntPtr pHandle , ref VersionInfo pVerInfo);


        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _GetAuthorInfo(PDEVICEHANDLE pHandle , AuthorInfo *pInfo)
		        函数名称：LPR _ GetAllVersion
		        函数说明：获取设备授权信息
		        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
				        pInfo：设备授权信息，见AuthorInfo定义
		        返回值：
		        返回值是RESULT_OK表示成功，否则返回错误代码


        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_GetAuthorInfo(IntPtr pHandle , ref AuthorInfo pInfo);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _SetAuthorInfo(PDEVICEHANDLE pHandle , AuthorInfo *pInfo)
        函数名称：LPR _ SetAuthorInfo
        函数说明：设置设备授权信息
        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        pInfo：设备授权信息，见AuthorInfo定义
        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码


        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_SetAuthorInfo( IntPtr pHandle ,ref  AuthorInfo pInfo);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _GetDeviceSerialNO(PDEVICEHANDLE pHandle , char *pSerialNO)
		        函数名称：LPR _ GetDeviceSerialNO
		        函数说明：获取设备序列号
		        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
				        pSerialNO：设备序列号，内存大小为SERIALNO_LEN
		        返回值：
		        返回值是RESULT_OK表示成功，否则返回错误代码



        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_GetDeviceSerialNO(IntPtr pHandle , StringBuilder pSerialNO);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _GetShutterValue(PDEVICEHANDLE pHandle , SHUTTER_PARAMS *pValue)
        函数名称：LPR _ GetShutterValue
        函数说明：获取设备快门值
        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        pValue：返回设备当前快门值，具体给值见SHUTTER_PARAMS定义
        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32  LPR_GetShutterValue(IntPtr pHandle , ref SHUTTER_PARAMS pValue);

        /*******************************************************************
        函数实体：unsigned int WINAPI LPR _SetShutterValue(PDEVICEHANDLE pHandle , SHUTTER_PARAMS Value)
        函数名称：LPR _ SetShutterValue
        函数说明：获取设备快门值
        参数说明:
        pHandle相机句柄，由LPR _ConnectCamera获取
        value：快门值，具体给值见SHUTTER_PARAMS定义
        返回值：
        返回值是RESULT_OK表示成功，否则返回错误代码
        **********************************************************************/

        [DllImport("LPRSDK.dll", CharSet = CharSet.Ansi)]
        public static extern UInt32 LPR_SetShutterValue(IntPtr pHandle, SHUTTER_PARAMS Value);

    }
}
