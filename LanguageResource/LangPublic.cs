using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageResource
{
    public class Lang
    {
        #region  多语言资源

			

				 ///<summary>令牌</summary>
 				  public static string access_token{
 				  get { return LangUtilities.GetString( "access_token"); }} 

				 ///<summary>中国银行户口</summary>
 				  public static string ACCOUNT_BOC_OF_HK{
 				  get { return LangUtilities.GetString( "ACCOUNT_BOC_OF_HK"); }} 

				 ///<summary>单击此处登录</summary>
 				  public static string Account_ConfirmEmail_ClickHereLogin{
 				  get { return LangUtilities.GetString( "Account_ConfirmEmail_ClickHereLogin"); }} 

				 ///<summary>感谢 ! 确认你的电子邮件。请</summary>
 				  public static string Account_ConfirmEmail_ThankYou{
 				  get { return LangUtilities.GetString( "Account_ConfirmEmail_ThankYou"); }} 

				 ///<summary>确认电子邮件</summary>
 				  public static string Account_ConfirmEmail_Title{
 				  get { return LangUtilities.GetString( "Account_ConfirmEmail_Title"); }} 

				 ///<summary>关联你的 {0} 帐户。</summary>
 				  public static string Account_ExternalLoginConfirmation_RelateToAccount{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginConfirmation_RelateToAccount"); }} 

				 ///<summary>关联表单</summary>
 				  public static string Account_ExternalLoginConfirmation_RelateToForm{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginConfirmation_RelateToForm"); }} 

				 ///<summary>你已成功使用 <strong>{0}</strong> 进行身份验证。请在下面输入此站点的用户名，然后单击“注册”按钮完成登录。</summary>
 				  public static string Account_ExternalLoginConfirmation_Succ{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginConfirmation_Succ"); }} 

				 ///<summary>注册</summary>
 				  public static string Account_ExternalLoginConfirmation_Title{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginConfirmation_Title"); }} 

				 ///<summary>使用服务登录失败。</summary>
 				  public static string Account_ExternalLoginFailure_H3LoginFail{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginFailure_H3LoginFail"); }} 

				 ///<summary>登录失败</summary>
 				  public static string Account_ExternalLoginFailure_LoginFail{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginFailure_LoginFail"); }} 

				 ///<summary>其他服务登录</summary>
 				  public static string Account_ExternalLoginsListPartial_OtherLoginService{
 				  get { return LangUtilities.GetString( "Account_ExternalLoginsListPartial_OtherLoginService"); }} 

				 ///<summary>提交不成功,服务器错误(F12):</summary>
 				  public static string Account_ForgotByPhone_Alert_msg_errForgotByPhone{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_Alert_msg_errForgotByPhone"); }} 

				 ///<summary>服务器端处理数据失败</summary>
 				  public static string Account_ForgotByPhone_Alertmsg_HandleForgotByPhone{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_Alertmsg_HandleForgotByPhone"); }} 

				 ///<summary>获取验证码</summary>
 				  public static string Account_ForgotByPhone_BtnCode{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_BtnCode"); }} 

				 ///<summary>获取验证码错误,请重新点击试试,code:500</summary>
 				  public static string Account_ForgotByPhone_BtnSendVerifyCodeClick_Alert{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_BtnSendVerifyCodeClick_Alert"); }} 

				 ///<summary>会话超时,请重新获取</summary>
 				  public static string Account_ForgotByPhone_CodeTimeOut{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_CodeTimeOut"); }} 

				 ///<summary>验证码不正确</summary>
 				  public static string Account_ForgotByPhone_CodeWrong{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_CodeWrong"); }} 

				 ///<summary>操作提示</summary>
 				  public static string Account_ForgotByPhone_HandleForgotByPhone_title{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_HandleForgotByPhone_title"); }} 

				 ///<summary>请通过单击 <a href=\"{0}\">此处</a>来重置你的密码"</summary>
 				  public static string Account_ForgotByPhone_SentCodeToEmailContent{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_SentCodeToEmailContent"); }} 

				 ///<summary>重置密码</summary>
 				  public static string Account_ForgotByPhone_SentCodeToEmailSubject{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_SentCodeToEmailSubject"); }} 

				 ///<summary>不存在会员资料</summary>
 				  public static string Account_ForgotByPhone_UserNotExist{
 				  get { return LangUtilities.GetString( "Account_ForgotByPhone_UserNotExist"); }} 

				 ///<summary>通过Email</summary>
 				  public static string Account_ForgotPassword_ByEmail{
 				  get { return LangUtilities.GetString( "Account_ForgotPassword_ByEmail"); }} 

				 ///<summary>通过手机</summary>
 				  public static string Account_ForgotPassword_ByPhoneNumber{
 				  get { return LangUtilities.GetString( "Account_ForgotPassword_ByPhoneNumber"); }} 

				 ///<summary>发送邮箱验证码</summary>
 				  public static string Account_ForgotPassword_SendEmailCode{
 				  get { return LangUtilities.GetString( "Account_ForgotPassword_SendEmailCode"); }} 

				 ///<summary>忘记了密码?</summary>
 				  public static string Account_ForgotPassword_Title{
 				  get { return LangUtilities.GetString( "Account_ForgotPassword_Title"); }} 

				 ///<summary>查看邮件以重置你的密码</summary>
 				  public static string Account_ForgotPasswordConfirmation_CheckEmailToResetPwd{
 				  get { return LangUtilities.GetString( "Account_ForgotPasswordConfirmation_CheckEmailToResetPwd"); }} 

				 ///<summary>忘记密码确认</summary>
 				  public static string Account_ForgotPasswordConfirmation_Title{
 				  get { return LangUtilities.GetString( "Account_ForgotPasswordConfirmation_Title"); }} 

				 ///<summary>忘记密码</summary>
 				  public static string Account_LoginMobile_DefinitedTag_ForgetPassword{
 				  get { return LangUtilities.GetString( "Account_LoginMobile_DefinitedTag_ForgetPassword"); }} 

				 ///<summary>注册新帐号</summary>
 				  public static string Account_LoginMobile_DefinitedTag_RegNew{
 				  get { return LangUtilities.GetString( "Account_LoginMobile_DefinitedTag_RegNew"); }} 

				 ///<summary>手机登录</summary>
 				  public static string Account_LoginMobile_Title{
 				  get { return LangUtilities.GetString( "Account_LoginMobile_Title"); }} 

				 ///<summary>会员登录</summary>
 				  public static string Account_LoginViewModel_DefinitedTag_BoxTitle{
 				  get { return LangUtilities.GetString( "Account_LoginViewModel_DefinitedTag_BoxTitle"); }} 

				 ///<summary>忘记密码</summary>
 				  public static string Account_LoginViewModel_DefinitedTag_ForgetPassword{
 				  get { return LangUtilities.GetString( "Account_LoginViewModel_DefinitedTag_ForgetPassword"); }} 

				 ///<summary>注册新帐号</summary>
 				  public static string Account_LoginViewModel_DefinitedTag_RegNew{
 				  get { return LangUtilities.GetString( "Account_LoginViewModel_DefinitedTag_RegNew"); }} 

				 ///<summary>Email登录</summary>
 				  public static string Account_LoginViewModel_Title{
 				  get { return LangUtilities.GetString( "Account_LoginViewModel_Title"); }} 

				 ///<summary>手机验证创建新帐户。</summary>
 				  public static string Account_MobileRegister_DefinitedTag_MobileCreateNew{
 				  get { return LangUtilities.GetString( "Account_MobileRegister_DefinitedTag_MobileCreateNew"); }} 

				 ///<summary>手机验证码无效，重新输入。</summary>
 				  public static string Account_MobileRegister_InvalidMobileVerifiedCode{
 				  get { return LangUtilities.GetString( "Account_MobileRegister_InvalidMobileVerifiedCode"); }} 

				 ///<summary>手机验证注册</summary>
 				  public static string Account_MobileRegister_Title{
 				  get { return LangUtilities.GetString( "Account_MobileRegister_Title"); }} 

				 ///<summary>请通过单击 <a href=\"{0}\" target=\"_blank\">点击这里</a>来确认你的帐户</summary>
 				  public static string Account_Register_confiredYourAcc{
 				  get { return LangUtilities.GetString( "Account_Register_confiredYourAcc"); }} 

				 ///<summary>确认你的帐户</summary>
 				  public static string Account_Register_confiredYourAccTitle{
 				  get { return LangUtilities.GetString( "Account_Register_confiredYourAccTitle"); }} 

				 ///<summary>注册成为会员</summary>
 				  public static string Account_Register_DefinitedTag_BoxTitle{
 				  get { return LangUtilities.GetString( "Account_Register_DefinitedTag_BoxTitle"); }} 

				 ///<summary>已注册,直接登录</summary>
 				  public static string Account_Register_DefinitedTag_HasRegistedToLogin{
 				  get { return LangUtilities.GetString( "Account_Register_DefinitedTag_HasRegistedToLogin"); }} 

				 ///<summary>会员注册</summary>
 				  public static string Account_Register_Title{
 				  get { return LangUtilities.GetString( "Account_Register_Title"); }} 

				 ///<summary>获取验证码错误\n\n请重新点击试试\n\n code:500</summary>
 				  public static string Account_RegMobile_BtnSendVerifyCode_errorMsg{
 				  get { return LangUtilities.GetString( "Account_RegMobile_BtnSendVerifyCode_errorMsg"); }} 

				 ///<summary>注册成为会员</summary>
 				  public static string Account_RegMobile_DefinitedTag_BoxTitle{
 				  get { return LangUtilities.GetString( "Account_RegMobile_DefinitedTag_BoxTitle"); }} 

				 ///<summary>已注册,直接登录</summary>
 				  public static string Account_RegMobile_DefinitedTag_HasRegistedToLogin{
 				  get { return LangUtilities.GetString( "Account_RegMobile_DefinitedTag_HasRegistedToLogin"); }} 

				 ///<summary>我同意服务&nbsp;<a href="#">条款</a></summary>
 				  public static string Account_RegMobile_DefinitedTag_Igree{
 				  get { return LangUtilities.GetString( "Account_RegMobile_DefinitedTag_Igree"); }} 

				 ///<summary>手机注册</summary>
 				  public static string Account_RegMobile_Title{
 				  get { return LangUtilities.GetString( "Account_RegMobile_Title"); }} 

				 ///<summary>单击此处登录。</summary>
 				  public static string Account_ResetPasswordConfirmation_ResetClickLogin{
 				  get { return LangUtilities.GetString( "Account_ResetPasswordConfirmation_ResetClickLogin"); }} 

				 ///<summary>你的密码已重置。</summary>
 				  public static string Account_ResetPasswordConfirmation_ResetPasswordTips{
 				  get { return LangUtilities.GetString( "Account_ResetPasswordConfirmation_ResetPasswordTips"); }} 

				 ///<summary>重置密码确认。</summary>
 				  public static string Account_ResetPasswordConfirmation_Title{
 				  get { return LangUtilities.GetString( "Account_ResetPasswordConfirmation_Title"); }} 

				 ///<summary>选择安全保护方式</summary>
 				  public static string Account_SendCode_DefinitedTag_ProTectedMode{
 				  get { return LangUtilities.GetString( "Account_SendCode_DefinitedTag_ProTectedMode"); }} 

				 ///<summary>安全保护</summary>
 				  public static string Account_SendCode_DefinitedTag_SecurityProtected{
 				  get { return LangUtilities.GetString( "Account_SendCode_DefinitedTag_SecurityProtected"); }} 

				 ///<summary>发送</summary>
 				  public static string Account_SendCode_Title{
 				  get { return LangUtilities.GetString( "Account_SendCode_Title"); }} 

				 ///<summary>请输入手机号码{0}</summary>
 				  public static string Account_SendVerifyCode_CheckPhoneNumBer{
 				  get { return LangUtilities.GetString( "Account_SendVerifyCode_CheckPhoneNumBer"); }} 

				 ///<summary>已发送到手机{0}</summary>
 				  public static string Account_SendVerifyCode_HasSendCodeMsg{
 				  get { return LangUtilities.GetString( "Account_SendVerifyCode_HasSendCodeMsg"); }} 

				 ///<summary>更新授权成功</summary>
 				  public static string Account_UserRolesAssignedUpdate_modalDialogViewMsg{
 				  get { return LangUtilities.GetString( "Account_UserRolesAssignedUpdate_modalDialogViewMsg"); }} 

				 ///<summary>安全保护</summary>
 				  public static string Account_VerifyCode_DefinitedTag_SecurityProtected{
 				  get { return LangUtilities.GetString( "Account_VerifyCode_DefinitedTag_SecurityProtected"); }} 

				 ///<summary>启动安全保护</summary>
 				  public static string Account_VerifyCode_Title{
 				  get { return LangUtilities.GetString( "Account_VerifyCode_Title"); }} 

				 ///<summary>ID</summary>
 				  public static string AccountDownLog_AccountDownLogID{
 				  get { return LangUtilities.GetString( "AccountDownLog_AccountDownLogID"); }} 

				 ///<summary>帐户ID</summary>
 				  public static string AccountDownLog_AccountMgrID{
 				  get { return LangUtilities.GetString( "AccountDownLog_AccountMgrID"); }} 

				 ///<summary>创建日期</summary>
 				  public static string AccountDownLog_CreatedDate{
 				  get { return LangUtilities.GetString( "AccountDownLog_CreatedDate"); }} 

				 ///<summary>操作日期</summary>
 				  public static string AccountDownLog_OperatedDate{
 				  get { return LangUtilities.GetString( "AccountDownLog_OperatedDate"); }} 

				 ///<summary>下載用户</summary>
 				  public static string AccountDownLog_OperatedUserName{
 				  get { return LangUtilities.GetString( "AccountDownLog_OperatedUserName"); }} 

				 ///<summary>单位序数</summary>
 				  public static string AccountDownLog_Rank{
 				  get { return LangUtilities.GetString( "AccountDownLog_Rank"); }} 

				 ///<summary>来源于资源文件</summary>
 				  public static string AccountDownLog_ResourceFile{
 				  get { return LangUtilities.GetString( "AccountDownLog_ResourceFile"); }} 

				 ///<summary>资源来源</summary>
 				  public static string AccountDownLog_TagName{
 				  get { return LangUtilities.GetString( "AccountDownLog_TagName"); }} 

				 ///<summary>资源来源ID</summary>
 				  public static string AccountDownLog_UserTagID{
 				  get { return LangUtilities.GetString( "AccountDownLog_UserTagID"); }} 

				 ///<summary>授權UserID</summary>
 				  public static string AccountMgr_AssignedToUserID{
 				  get { return LangUtilities.GetString( "AccountMgr_AssignedToUserID"); }} 

				 ///<summary>创建者</summary>
 				  public static string AccountMgr_CreatedByUserID{
 				  get { return LangUtilities.GetString( "AccountMgr_CreatedByUserID"); }} 

				 ///<summary>证书</summary>
 				  public static string AccountMgr_IsCer{
 				  get { return LangUtilities.GetString( "AccountMgr_IsCer"); }} 

				 ///<summary>登录EMail</summary>
 				  public static string AccountMgr_LoginEmail{
 				  get { return LangUtilities.GetString( "AccountMgr_LoginEmail"); }} 

				 ///<summary>账号ID</summary>
 				  public static string AccountMgr_LoginID{
 				  get { return LangUtilities.GetString( "AccountMgr_LoginID"); }} 

				 ///<summary>註冊手機</summary>
 				  public static string AccountMgr_Mobile{
 				  get { return LangUtilities.GetString( "AccountMgr_Mobile"); }} 

				 ///<summary>暱稱</summary>
 				  public static string AccountMgr_NickName{
 				  get { return LangUtilities.GetString( "AccountMgr_NickName"); }} 

				 ///<summary>操作日期</summary>
 				  public static string AccountMgr_OperatedDate{
 				  get { return LangUtilities.GetString( "AccountMgr_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string AccountMgr_OperatedUserName{
 				  get { return LangUtilities.GetString( "AccountMgr_OperatedUserName"); }} 

				 ///<summary>密碼</summary>
 				  public static string AccountMgr_Password{
 				  get { return LangUtilities.GetString( "AccountMgr_Password"); }} 

				 ///<summary>密碼2</summary>
 				  public static string AccountMgr_Password2{
 				  get { return LangUtilities.GetString( "AccountMgr_Password2"); }} 

				 ///<summary>答案</summary>
 				  public static string AccountMgr_PrivacyAnswer{
 				  get { return LangUtilities.GetString( "AccountMgr_PrivacyAnswer"); }} 

				 ///<summary>安全問題</summary>
 				  public static string AccountMgr_PrivacyQuestion{
 				  get { return LangUtilities.GetString( "AccountMgr_PrivacyQuestion"); }} 

				 ///<summary>備註</summary>
 				  public static string AccountMgr_Remarks{
 				  get { return LangUtilities.GetString( "AccountMgr_Remarks"); }} 

				 ///<summary>安全EMail</summary>
 				  public static string AccountMgr_ScurityEmail{
 				  get { return LangUtilities.GetString( "AccountMgr_ScurityEmail"); }} 

				 ///<summary>操作日期</summary>
 				  public static string AccountMgr_ShopID{
 				  get { return LangUtilities.GetString( "AccountMgr_ShopID"); }} 

				 ///<summary>网站名称</summary>
 				  public static string AccountMgr_SiteName{
 				  get { return LangUtilities.GetString( "AccountMgr_SiteName"); }} 

				 ///<summary>网址</summary>
 				  public static string AccountMgr_WebSite{
 				  get { return LangUtilities.GetString( "AccountMgr_WebSite"); }} 

				 ///<summary>是否使用证书加密</summary>
 				  public static string AccountMgrAddOrUpd_ShowTitleThumbNail_IsInUseCer{
 				  get { return LangUtilities.GetString( "AccountMgrAddOrUpd_ShowTitleThumbNail_IsInUseCer"); }} 

				 ///<summary>下载当前渠道推广客户资源(手机通讯录格式)</summary>
 				  public static string AccountMgrList_AccountDownloadFormat{
 				  get { return LangUtilities.GetString( "AccountMgrList_AccountDownloadFormat"); }} 

				 ///<summary>推广帐号列表</summary>
 				  public static string AccountMgrList_Accountlist{
 				  get { return LangUtilities.GetString( "AccountMgrList_Accountlist"); }} 

				 ///<summary>输入获取数据...</summary>
 				  public static string AccountMgrList_Inputtogetdata{
 				  get { return LangUtilities.GetString( "AccountMgrList_Inputtogetdata"); }} 

				 ///<summary>下载当前渠道推广客户资源(手机通讯录格式)</summary>
 				  public static string AccountMgrList_JS_AccountDownloadFormat{
 				  get { return LangUtilities.GetString( "AccountMgrList_JS_AccountDownloadFormat"); }} 

				 ///<summary>推广帐号注册是哪个平台或网站</summary>
 				  public static string AccountMgrList_Whichplatformpromotion{
 				  get { return LangUtilities.GetString( "AccountMgrList_Whichplatformpromotion"); }} 

				 ///<summary>网站名称</summary>
 				  public static string AccountWebSite_SiteName{
 				  get { return LangUtilities.GetString( "AccountWebSite_SiteName"); }} 

				 ///<summary>网址</summary>
 				  public static string AccountWebSite_WebSite{
 				  get { return LangUtilities.GetString( "AccountWebSite_WebSite"); }} 

				 ///<summary>验证码</summary>
 				  public static string AddPhoneNumberViewModel_ImageCode{
 				  get { return LangUtilities.GetString( "AddPhoneNumberViewModel_ImageCode"); }} 

				 ///<summary>手机号码</summary>
 				  public static string AddPhoneNumberViewModel_Number{
 				  get { return LangUtilities.GetString( "AddPhoneNumberViewModel_Number"); }} 

				 ///<summary>请选择交易属性哦</summary>
 				  public static string AddToCart_ClickBtnAddToCartOK_strPlsSelect{
 				  get { return LangUtilities.GetString( "AddToCart_ClickBtnAddToCartOK_strPlsSelect"); }} 

				 ///<summary>生成资源结果</summary>
 				  public static string AsignToAccountMgrID_GenerateResult{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_GenerateResult"); }} 

				 ///<summary>分配帐号资源</summary>
 				  public static string AsignToAccountMgrID_h3{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_h3"); }} 

				 ///<summary>独占资源</summary>
 				  public static string AsignToAccountMgrID_IsMonopoly{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_IsMonopoly"); }} 

				 ///<summary>登录EMail</summary>
 				  public static string AsignToAccountMgrID_LoginEmail{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_LoginEmail"); }} 

				 ///<summary>帐号登录ID</summary>
 				  public static string AsignToAccountMgrID_LoginID{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_LoginID"); }} 

				 ///<summary>注册手机</summary>
 				  public static string AsignToAccountMgrID_Mobile{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_Mobile"); }} 

				 ///<summary>网站平台</summary>
 				  public static string AsignToAccountMgrID_SiteName{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_SiteName"); }} 

				 ///<summary>分配资源数量</summary>
 				  public static string AsignToAccountMgrID_Take{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_Take"); }} 

				 ///<summary>资源来源</summary>
 				  public static string AsignToAccountMgrID_UserTagID{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_UserTagID"); }} 

				 ///<summary>分配数量太大，请联系管理员</summary>
 				  public static string AsignToAccountMgrID_ValidationMsg{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrID_ValidationMsg"); }} 

				 ///<summary>生成资源</summary>
 				  public static string AsignToAccountMgrIDResult_GenerateResult{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrIDResult_GenerateResult"); }} 

				 ///<summary>帐号登录ID</summary>
 				  public static string AsignToAccountMgrIDResult_LoginID{
 				  get { return LangUtilities.GetString( "AsignToAccountMgrIDResult_LoginID"); }} 

				 ///<summary>验证码</summary>
 				  public static string AspNetUsers_Code{
 				  get { return LangUtilities.GetString( "AspNetUsers_Code"); }} 

				 ///<summary>确认密码</summary>
 				  public static string AspNetUsers_ConfirmPassword{
 				  get { return LangUtilities.GetString( "AspNetUsers_ConfirmPassword"); }} 

				 ///<summary>Email</summary>
 				  public static string AspNetUsers_Email{
 				  get { return LangUtilities.GetString( "AspNetUsers_Email"); }} 

				 ///<summary>密码</summary>
 				  public static string AspNetUsers_Password{
 				  get { return LangUtilities.GetString( "AspNetUsers_Password"); }} 

				 ///<summary>手机号码</summary>
 				  public static string AspNetUsers_PhoneNumber{
 				  get { return LangUtilities.GetString( "AspNetUsers_PhoneNumber"); }} 

				 ///<summary>记住此浏览器?</summary>
 				  public static string AspNetUsers_RememberBrowser{
 				  get { return LangUtilities.GetString( "AspNetUsers_RememberBrowser"); }} 

				 ///<summary>记住我?</summary>
 				  public static string AspNetUsers_RememberMe{
 				  get { return LangUtilities.GetString( "AspNetUsers_RememberMe"); }} 

				 ///<summary>用户ID</summary>
 				  public static string AspNetUsers_UserId{
 				  get { return LangUtilities.GetString( "AspNetUsers_UserId"); }} 

				 ///<summary>请输入正确的信用卡格式</summary>
 				  public static string AttributeExtensions_CreditCardAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_CreditCardAttribute"); }} 

				 ///<summary>必須符合数字格式 如 12-12345678-1</summary>
 				  public static string AttributeExtensions_CuitAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_CuitAttribute"); }} 

				 ///<summary>请输入正确日期格式</summary>
 				  public static string AttributeExtensions_DateAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_DateAttribute"); }} 

				 ///<summary>请输入数字</summary>
 				  public static string AttributeExtensions_DigitsAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_DigitsAttribute"); }} 

				 ///<summary>请输入正确的Email格式</summary>
 				  public static string AttributeExtensions_EmailAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_EmailAttribute"); }} 

				 ///<summary>{0}不一致</summary>
 				  public static string AttributeExtensions_EqualToAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_EqualToAttribute"); }} 

				 ///<summary>仅接受文件类型:.png,jpg,jpeg,gif</summary>
 				  public static string AttributeExtensions_FileExtensionsAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_FileExtensionsAttribute"); }} 

				 ///<summary>{0}必须小于或等于{1}</summary>
 				  public static string AttributeExtensions_MaxAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_MaxAttribute"); }} 

				 ///<summary>{0}必须大于{1}</summary>
 				  public static string AttributeExtensions_MinAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_MinAttribute"); }} 

				 ///<summary>请输入有效的数字</summary>
 				  public static string AttributeExtensions_NumericAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_NumericAttribute"); }} 

				 ///<summary>手机号码</summary>
 				  public static string AttributeExtensions_PhoneNumber{
 				  get { return LangUtilities.GetString( "AttributeExtensions_PhoneNumber"); }} 

				 ///<summary>输入的手机号码不正确,格式如: 13812345678</summary>
 				  public static string AttributeExtensions_PhoneNumberAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_PhoneNumberAttribute"); }} 

				 ///<summary>请输入完整的url连接</summary>
 				  public static string AttributeExtensions_UrlAttribute_Optional_Invalid{
 				  get { return LangUtilities.GetString( "AttributeExtensions_UrlAttribute_Optional_Invalid"); }} 

				 ///<summary>无效的URL</summary>
 				  public static string AttributeExtensions_UrlAttribute_Protocol_Invalid{
 				  get { return LangUtilities.GetString( "AttributeExtensions_UrlAttribute_Protocol_Invalid"); }} 

				 ///<summary>请输入有效的http,https,ftp等开头的链接</summary>
 				  public static string AttributeExtensions_UrlAttribute_validHttp{
 				  get { return LangUtilities.GetString( "AttributeExtensions_UrlAttribute_validHttp"); }} 

				 ///<summary>请输入有效年份格式</summary>
 				  public static string AttributeExtensions_YearAttribute{
 				  get { return LangUtilities.GetString( "AttributeExtensions_YearAttribute"); }} 

				 ///<summary>ID</summary>
 				  public static string BlockList_BlockListId{
 				  get { return LangUtilities.GetString( "BlockList_BlockListId"); }} 

				 ///<summary>EMail</summary>
 				  public static string BlockList_EMail{
 				  get { return LangUtilities.GetString( "BlockList_EMail"); }} 

				 ///<summary>姓名</summary>
 				  public static string BlockList_Name{
 				  get { return LangUtilities.GetString( "BlockList_Name"); }} 

				 ///<summary>操作日期</summary>
 				  public static string BlockList_OperatedDate{
 				  get { return LangUtilities.GetString( "BlockList_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string BlockList_OperatedUserName{
 				  get { return LangUtilities.GetString( "BlockList_OperatedUserName"); }} 

				 ///<summary>拉黑手机号</summary>
 				  public static string BlockList_PhoneNumber{
 				  get { return LangUtilities.GetString( "BlockList_PhoneNumber"); }} 

				 ///<summary>备注</summary>
 				  public static string BlockList_Remarks{
 				  get { return LangUtilities.GetString( "BlockList_Remarks"); }} 

				 ///<summary>ShopID</summary>
 				  public static string BlockList_ShopID{
 				  get { return LangUtilities.GetString( "BlockList_ShopID"); }} 

				 ///<summary>创建日期</summary>
 				  public static string Cart_CreatedDate{
 				  get { return LangUtilities.GetString( "Cart_CreatedDate"); }} 

				 ///<summary>更新日期</summary>
 				  public static string Cart_OperatedDate{
 				  get { return LangUtilities.GetString( "Cart_OperatedDate"); }} 

				 ///<summary>产品名称</summary>
 				  public static string Cart_ProductName{
 				  get { return LangUtilities.GetString( "Cart_ProductName"); }} 

				 ///<summary>属性描述</summary>
 				  public static string Cart_PropertyDesc{
 				  get { return LangUtilities.GetString( "Cart_PropertyDesc"); }} 

				 ///<summary>属性名称1</summary>
 				  public static string Cart_PropName1{
 				  get { return LangUtilities.GetString( "Cart_PropName1"); }} 

				 ///<summary>属性名称2</summary>
 				  public static string Cart_PropName2{
 				  get { return LangUtilities.GetString( "Cart_PropName2"); }} 

				 ///<summary>属性值1</summary>
 				  public static string Cart_PropValue1{
 				  get { return LangUtilities.GetString( "Cart_PropValue1"); }} 

				 ///<summary>属性值2</summary>
 				  public static string Cart_PropValue2{
 				  get { return LangUtilities.GetString( "Cart_PropValue2"); }} 

				 ///<summary>数量</summary>
 				  public static string Cart_Quantity{
 				  get { return LangUtilities.GetString( "Cart_Quantity"); }} 

				 ///<summary>零售价</summary>
 				  public static string Cart_RetailPrice{
 				  get { return LangUtilities.GetString( "Cart_RetailPrice"); }} 

				 ///<summary>Sku规格图</summary>
 				  public static string Cart_SkuImageUrl{
 				  get { return LangUtilities.GetString( "Cart_SkuImageUrl"); }} 

				 ///<summary>成交价</summary>
 				  public static string Cart_TradePrice{
 				  get { return LangUtilities.GetString( "Cart_TradePrice"); }} 

				 ///<summary>店内分类描述</summary>
 				  public static string Category_CategoryDesc{
 				  get { return LangUtilities.GetString( "Category_CategoryDesc"); }} 

				 ///<summary>店内分类ID</summary>
 				  public static string Category_CategoryID{
 				  get { return LangUtilities.GetString( "Category_CategoryID"); }} 

				 ///<summary>店内分类名称</summary>
 				  public static string Category_CategoryName{
 				  get { return LangUtilities.GetString( "Category_CategoryName"); }} 

				 ///<summary>操作用户</summary>
 				  public static string Category_OperatedUserName{
 				  get { return LangUtilities.GetString( "Category_OperatedUserName"); }} 

				 ///<summary>父类ID</summary>
 				  public static string Category_ParentsCategoryID{
 				  get { return LangUtilities.GetString( "Category_ParentsCategoryID"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string Category_ShopID{
 				  get { return LangUtilities.GetString( "Category_ShopID"); }} 

				 ///<summary>资讯渠道ID</summary>
 				  public static string Changel_ChangelID{
 				  get { return LangUtilities.GetString( "Changel_ChangelID"); }} 

				 ///<summary>名称格式例如:CH00000001,CH为前缀</summary>
 				  public static string Changel_ChangelID_StringLength_ErrMsg{
 				  get { return LangUtilities.GetString( "Changel_ChangelID_StringLength_ErrMsg"); }} 

				 ///<summary>资讯渠道名称</summary>
 				  public static string Changel_ChangelName{
 				  get { return LangUtilities.GetString( "Changel_ChangelName"); }} 

				 ///<summary>必填字段名称</summary>
 				  public static string Changel_ChangelName_StringLength_ErrMsg{
 				  get { return LangUtilities.GetString( "Changel_ChangelName_StringLength_ErrMsg"); }} 

				 ///<summary>资讯渠道连接</summary>
 				  public static string Changel_ChangelUrl{
 				  get { return LangUtilities.GetString( "Changel_ChangelUrl"); }} 

				 ///<summary>连接格式错误</summary>
 				  public static string Changel_ChangelUrl_RegularExpression_ErrMsg{
 				  get { return LangUtilities.GetString( "Changel_ChangelUrl_RegularExpression_ErrMsg"); }} 

				 ///<summary>资讯渠道连接，例如：http://blog.sina.com.cn/ （没有具体连接则上一级域名目录）</summary>
 				  public static string Changel_ChangelUrl_StringLength_ErrMsg{
 				  get { return LangUtilities.GetString( "Changel_ChangelUrl_StringLength_ErrMsg"); }} 

				 ///<summary>确认新密码</summary>
 				  public static string ChangePasswordViewModel_ConfirmPassword{
 				  get { return LangUtilities.GetString( "ChangePasswordViewModel_ConfirmPassword"); }} 

				 ///<summary>新密码</summary>
 				  public static string ChangePasswordViewModel_NewPassword{
 				  get { return LangUtilities.GetString( "ChangePasswordViewModel_NewPassword"); }} 

				 ///<summary>当前密码</summary>
 				  public static string ChangePasswordViewModel_OldPassword{
 				  get { return LangUtilities.GetString( "ChangePasswordViewModel_OldPassword"); }} 

				 ///<summary>复利终值</summary>
 				  public static string CompoundInterestView_F{
 				  get { return LangUtilities.GetString( "CompoundInterestView_F"); }} 

				 ///<summary>利率</summary>
 				  public static string CompoundInterestView_i{
 				  get { return LangUtilities.GetString( "CompoundInterestView_i"); }} 

				 ///<summary>年期</summary>
 				  public static string CompoundInterestView_n{
 				  get { return LangUtilities.GetString( "CompoundInterestView_n"); }} 

				 ///<summary>复利初值</summary>
 				  public static string CompoundInterestView_P{
 				  get { return LangUtilities.GetString( "CompoundInterestView_P"); }} 

				 ///<summary>沒有选择要购买的商品哦~~~</summary>
 				  public static string ControllerName_ActionMethod_MyShoppingCart_layerTips{
 				  get { return LangUtilities.GetString( "ControllerName_ActionMethod_MyShoppingCart_layerTips"); }} 

				 ///<summary>订单列表</summary>
 				  public static string ControllerName_Views_DefinitedUI_ConfirmOrderAnouncement{
 				  get { return LangUtilities.GetString( "ControllerName_Views_DefinitedUI_ConfirmOrderAnouncement"); }} 

				 ///<summary>0元为无条件使用,限定订单金额满X元才可以使用</summary>
 				  public static string CouponList_Label_Title_CouponUsage{
 				  get { return LangUtilities.GetString( "CouponList_Label_Title_CouponUsage"); }} 

				 ///<summary>无效的会员登录帐号或优惠券编号</summary>
 				  public static string CouponList_SaveChanges1_Alert{
 				  get { return LangUtilities.GetString( "CouponList_SaveChanges1_Alert"); }} 

				 ///<summary>活动管理</summary>
 				  public static string CouponList_SubTitle{
 				  get { return LangUtilities.GetString( "CouponList_SubTitle"); }} 

				 ///<summary>优惠券列表</summary>
 				  public static string CouponList_Title{
 				  get { return LangUtilities.GetString( "CouponList_Title"); }} 

				 ///<summary>派发优惠券</summary>
 				  public static string CouponList_UserCouponAdd_h4{
 				  get { return LangUtilities.GetString( "CouponList_UserCouponAdd_h4"); }} 

				 ///<summary>请选择属性</summary>
 				  public static string CreateSku_BtnCreateSkuOK_Tips_SelectProp{
 				  get { return LangUtilities.GetString( "CreateSku_BtnCreateSkuOK_Tips_SelectProp"); }} 

				 ///<summary>SKU已存在，并更新对应的数据。</summary>
 				  public static string CreateSku_createSku_ModalDialogView1{
 				  get { return LangUtilities.GetString( "CreateSku_createSku_ModalDialogView1"); }} 

				 ///<summary>上存SKU图</summary>
 				  public static string CreateSku_DefinitedUI_UploadSkuPic{
 				  get { return LangUtilities.GetString( "CreateSku_DefinitedUI_UploadSkuPic"); }} 

				 ///<summary>量化因子列表</summary>
 				  public static string CustQuantization_PopUpUserQuantFactorList_title{
 				  get { return LangUtilities.GetString( "CustQuantization_PopUpUserQuantFactorList_title"); }} 

				 ///<summary>按量化分值权重排序</summary>
 				  public static string CustQuantization_SortRank_Title{
 				  get { return LangUtilities.GetString( "CustQuantization_SortRank_Title"); }} 

				 ///<summary>潜在客户权重量化列表</summary>
 				  public static string CustQuantization_Title{
 				  get { return LangUtilities.GetString( "CustQuantization_Title"); }} 

				 ///<summary>最佳格式220X43</summary>
 				  public static string DefinitedTag_ProperSize{
 				  get { return LangUtilities.GetString( "DefinitedTag_ProperSize"); }} 

				 ///<summary>模板ID</summary>
 				  public static string DefiniteTemplateNote_DefiniteTemplateNoteId{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_DefiniteTemplateNoteId"); }} 

				 ///<summary>打印模板名称</summary>
 				  public static string DefiniteTemplateNote_DefiniteTemplateNoteName{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_DefiniteTemplateNoteName"); }} 

				 ///<summary>模板图片</summary>
 				  public static string DefiniteTemplateNote_DefiniteTemplatePicture{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_DefiniteTemplatePicture"); }} 

				 ///<summary>模板高度度</summary>
 				  public static string DefiniteTemplateNote_Height{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_Height"); }} 

				 ///<summary>操作时间</summary>
 				  public static string DefiniteTemplateNote_OperatedDate{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string DefiniteTemplateNote_OperatedUserName{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_OperatedUserName"); }} 

				 ///<summary>收件人字段</summary>
 				  public static string DefiniteTemplateNote_RecipientColFields{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_RecipientColFields"); }} 

				 ///<summary>发件人字段</summary>
 				  public static string DefiniteTemplateNote_SenderColFields{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_SenderColFields"); }} 

				 ///<summary>发件人地址</summary>
 				  public static string DefiniteTemplateNote_SenderUserAddressID{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_SenderUserAddressID"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string DefiniteTemplateNote_ShopID{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_ShopID"); }} 

				 ///<summary>模板宽度</summary>
 				  public static string DefiniteTemplateNote_Width{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNote_Width"); }} 

				 ///<summary>字段选择</summary>
 				  public static string DefiniteTemplateNoteCreate_SubTitle{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNoteCreate_SubTitle"); }} 

				 ///<summary>打印模板定义</summary>
 				  public static string DefiniteTemplateNoteCreate_Title{
 				  get { return LangUtilities.GetString( "DefiniteTemplateNoteCreate_Title"); }} 

				 ///<summary>Email任务删除确认</summary>
 				  public static string DeleteEmailTask_ComfirmTips{
 				  get { return LangUtilities.GetString( "DeleteEmailTask_ComfirmTips"); }} 

				 ///<summary>删除发送邮件信息确认提示</summary>
 				  public static string DeleteSendMailInfo_ComfirmTips{
 				  get { return LangUtilities.GetString( "DeleteSendMailInfo_ComfirmTips"); }} 

				 ///<summary>详细地址</summary>
 				  public static string DispatchNote_Address{
 				  get { return LangUtilities.GetString( "DispatchNote_Address"); }} 

				 ///<summary>所在国家</summary>
 				  public static string DispatchNote_Country{
 				  get { return LangUtilities.GetString( "DispatchNote_Country"); }} 

				 ///<summary>创建日期</summary>
 				  public static string DispatchNote_CreatedDate{
 				  get { return LangUtilities.GetString( "DispatchNote_CreatedDate"); }} 

				 ///<summary>所在县区</summary>
 				  public static string DispatchNote_District{
 				  get { return LangUtilities.GetString( "DispatchNote_District"); }} 

				 ///<summary>授权</summary>
 				  public static string Dispatchnote_Index_Authorized{
 				  get { return LangUtilities.GetString( "Dispatchnote_Index_Authorized"); }} 

				 ///<summary>訂單發貨列表</summary>
 				  public static string Dispatchnote_Index_SubTitle{
 				  get { return LangUtilities.GetString( "Dispatchnote_Index_SubTitle"); }} 

				 ///<summary>发货单审核列表</summary>
 				  public static string Dispatchnote_Index_Title{
 				  get { return LangUtilities.GetString( "Dispatchnote_Index_Title"); }} 

				 ///<summary>货号</summary>
 				  public static string DispatchNote_payment_no{
 				  get { return LangUtilities.GetString( "DispatchNote_payment_no"); }} 

				 ///<summary>手机号码</summary>
 				  public static string DispatchNote_PhoneNumber{
 				  get { return LangUtilities.GetString( "DispatchNote_PhoneNumber"); }} 

				 ///<summary>邮政编号</summary>
 				  public static string DispatchNote_PostCode{
 				  get { return LangUtilities.GetString( "DispatchNote_PostCode"); }} 

				 ///<summary>数量</summary>
 				  public static string DispatchNote_Quantity{
 				  get { return LangUtilities.GetString( "DispatchNote_Quantity"); }} 

				 ///<summary>收件地址</summary>
 				  public static string DispatchNote_Recipien_Address{
 				  get { return LangUtilities.GetString( "DispatchNote_Recipien_Address"); }} 

				 ///<summary>收件人</summary>
 				  public static string DispatchNote_Recipient{
 				  get { return LangUtilities.GetString( "DispatchNote_Recipient"); }} 

				 ///<summary>RecommUserId</summary>
 				  public static string DispatchNote_RecommUserId{
 				  get { return LangUtilities.GetString( "DispatchNote_RecommUserId"); }} 

				 ///<summary>备 注</summary>
 				  public static string DispatchNote_Remarks{
 				  get { return LangUtilities.GetString( "DispatchNote_Remarks"); }} 

				 ///<summary>发货状态</summary>
 				  public static string DispatchNote_ShopID{
 				  get { return LangUtilities.GetString( "DispatchNote_ShopID"); }} 

				 ///<summary>所在州省</summary>
 				  public static string DispatchNote_State{
 				  get { return LangUtilities.GetString( "DispatchNote_State"); }} 

				 ///<summary>状态</summary>
 				  public static string DispatchNote_StatusName{
 				  get { return LangUtilities.GetString( "DispatchNote_StatusName"); }} 

				 ///<summary>货号</summary>
 				  public static string DispatchNote_StyleNo{
 				  get { return LangUtilities.GetString( "DispatchNote_StyleNo"); }} 

				 ///<summary>电话号码</summary>
 				  public static string DispatchNote_TelePhoneNumber{
 				  get { return LangUtilities.GetString( "DispatchNote_TelePhoneNumber"); }} 

				 ///<summary>马上订购</summary>
 				  public static string DispatchNoteModalView_DefinitedTag_BoxTitle{
 				  get { return LangUtilities.GetString( "DispatchNoteModalView_DefinitedTag_BoxTitle"); }} 

				 ///<summary>发货单授权</summary>
 				  public static string DispatchNoteModalView_DefinitedTag_FinanceAuthorize{
 				  get { return LangUtilities.GetString( "DispatchNoteModalView_DefinitedTag_FinanceAuthorize"); }} 

				 ///<summary>微信付款</summary>
 				  public static string DispatchNoteModalView_DefinitedTag_SubmitAndPay{
 				  get { return LangUtilities.GetString( "DispatchNoteModalView_DefinitedTag_SubmitAndPay"); }} 

				 ///<summary>新增成功，感谢你的购买</summary>
 				  public static string DispatchNoteView_thankForBuy{
 				  get { return LangUtilities.GetString( "DispatchNoteView_thankForBuy"); }} 

				 ///<summary>地区ID</summary>
 				  public static string District_DistrictID{
 				  get { return LangUtilities.GetString( "District_DistrictID"); }} 

				 ///<summary>地区名称</summary>
 				  public static string District_DistrictName{
 				  get { return LangUtilities.GetString( "District_DistrictName"); }} 

				 ///<summary>字母索引</summary>
 				  public static string District_FirstLetter{
 				  get { return LangUtilities.GetString( "District_FirstLetter"); }} 

				 ///<summary>角色授权</summary>
 				  public static string District_ForRoleName{
 				  get { return LangUtilities.GetString( "District_ForRoleName"); }} 

				 ///<summary>层</summary>
 				  public static string District_Levels{
 				  get { return LangUtilities.GetString( "District_Levels"); }} 

				 ///<summary>菜单ID</summary>
 				  public static string District_MenuItemID{
 				  get { return LangUtilities.GetString( "District_MenuItemID"); }} 

				 ///<summary>菜单名称</summary>
 				  public static string District_MenuItemName{
 				  get { return LangUtilities.GetString( "District_MenuItemName"); }} 

				 ///<summary>连接</summary>
 				  public static string District_MenuLink{
 				  get { return LangUtilities.GetString( "District_MenuLink"); }} 

				 ///<summary>操作日期</summary>
 				  public static string District_OperatedDate{
 				  get { return LangUtilities.GetString( "District_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string District_OperatedUserName{
 				  get { return LangUtilities.GetString( "District_OperatedUserName"); }} 

				 ///<summary>所属地区(ID)</summary>
 				  public static string District_Parent_id{
 				  get { return LangUtilities.GetString( "District_Parent_id"); }} 

				 ///<summary>父菜单ID</summary>
 				  public static string District_ParentsMenuItemID{
 				  get { return LangUtilities.GetString( "District_ParentsMenuItemID"); }} 

				 ///<summary>打开方式</summary>
 				  public static string District_Target{
 				  get { return LangUtilities.GetString( "District_Target"); }} 

				 ///<summary>Access Key</summary>
 				  public static string EmailSms_AccessKey{
 				  get { return LangUtilities.GetString( "EmailSms_AccessKey"); }} 

				 ///<summary>凭证用户名</summary>
 				  public static string EmailSms_credentialUserName{
 				  get { return LangUtilities.GetString( "EmailSms_credentialUserName"); }} 

				 ///<summary>操作时间</summary>
 				  public static string EmailSms_OperatedDate{
 				  get { return LangUtilities.GetString( "EmailSms_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string EmailSms_OperatedUserName{
 				  get { return LangUtilities.GetString( "EmailSms_OperatedUserName"); }} 

				 ///<summary>端口号</summary>
 				  public static string EmailSms_Port{
 				  get { return LangUtilities.GetString( "EmailSms_Port"); }} 

				 ///<summary>发Email的密码</summary>
 				  public static string EmailSms_pwd{
 				  get { return LangUtilities.GetString( "EmailSms_pwd"); }} 

				 ///<summary>Secret</summary>
 				  public static string EmailSms_Secret{
 				  get { return LangUtilities.GetString( "EmailSms_Secret"); }} 

				 ///<summary>Email来自</summary>
 				  public static string EmailSms_sentFrom{
 				  get { return LangUtilities.GetString( "EmailSms_sentFrom"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string EmailSms_ShopID{
 				  get { return LangUtilities.GetString( "EmailSms_ShopID"); }} 

				 ///<summary>网址</summary>
 				  public static string EmailSms_ShopWebsite{
 				  get { return LangUtilities.GetString( "EmailSms_ShopWebsite"); }} 

				 ///<summary>SignName</summary>
 				  public static string EmailSms_SignName{
 				  get { return LangUtilities.GetString( "EmailSms_SignName"); }} 

				 ///<summary>SmtpClient</summary>
 				  public static string EmailSms_SmtpClient{
 				  get { return LangUtilities.GetString( "EmailSms_SmtpClient"); }} 

				 ///<summary>模板编号</summary>
 				  public static string EmailSms_TemplateCode{
 				  get { return LangUtilities.GetString( "EmailSms_TemplateCode"); }} 

				 ///<summary>无效EMAIL</summary>
 				  public static string EmailSubscribe_EmailInvalid{
 				  get { return LangUtilities.GetString( "EmailSubscribe_EmailInvalid"); }} 

				 ///<summary>订阅</summary>
 				  public static string EmailSubscribe_Subscribe{
 				  get { return LangUtilities.GetString( "EmailSubscribe_Subscribe"); }} 

				 ///<summary>上存EMAIL模板</summary>
 				  public static string EmailSubscribe_Title{
 				  get { return LangUtilities.GetString( "EmailSubscribe_Title"); }} 

				 ///<summary>回传链接</summary>
 				  public static string EmailTask_CallBackUrl{
 				  get { return LangUtilities.GetString( "EmailTask_CallBackUrl"); }} 

				 ///<summary>如模板Href链接标签有设置{callbackurl}，则会替换。如果取值空白，则忽略此规则。</summary>
 				  public static string EmailTask_CallBackUrlRule{
 				  get { return LangUtilities.GetString( "EmailTask_CallBackUrlRule"); }} 

				 ///<summary>Email任务名称</summary>
 				  public static string EmailTask_Name{
 				  get { return LangUtilities.GetString( "EmailTask_Name"); }} 

				 ///<summary>操作日期</summary>
 				  public static string EmailTask_OperatedDate{
 				  get { return LangUtilities.GetString( "EmailTask_OperatedDate"); }} 

				 ///<summary>操作者</summary>
 				  public static string EmailTask_OperatedUserName{
 				  get { return LangUtilities.GetString( "EmailTask_OperatedUserName"); }} 

				 ///<summary>邮件服务发送账号</summary>
 				  public static string EmailTask_SenderAccountArr{
 				  get { return LangUtilities.GetString( "EmailTask_SenderAccountArr"); }} 

				 ///<summary>发送邮件使用越多账号发送，成功的几率越高。同时要看具体email账号质量。</summary>
 				  public static string EmailTask_SenderAccountArrRule{
 				  get { return LangUtilities.GetString( "EmailTask_SenderAccountArrRule"); }} 

				 ///<summary>任务状态</summary>
 				  public static string EmailTask_Status{
 				  get { return LangUtilities.GetString( "EmailTask_Status"); }} 

				 ///<summary>邮件标题</summary>
 				  public static string EmailTask_Subject{
 				  get { return LangUtilities.GetString( "EmailTask_Subject"); }} 

				 ///<summary>如果标题空白，则使用模板前20个字作为标题。</summary>
 				  public static string EmailTask_SubjectBlankRule{
 				  get { return LangUtilities.GetString( "EmailTask_SubjectBlankRule"); }} 

				 ///<summary>Email任务列表</summary>
 				  public static string EmailTask_Title{
 				  get { return LangUtilities.GetString( "EmailTask_Title"); }} 

				 ///<summary>手机号码</summary>
 				  public static string ForgotByPhoneViewModel_PhoneNumber{
 				  get { return LangUtilities.GetString( "ForgotByPhoneViewModel_PhoneNumber"); }} 

				 ///<summary>电子邮件</summary>
 				  public static string ForgotPasswordViewModel_Email{
 				  get { return LangUtilities.GetString( "ForgotPasswordViewModel_Email"); }} 

				 ///<summary>韩元</summary>
 				  public static string GeneralLogic_deDE{
 				  get { return LangUtilities.GetString( "GeneralLogic_deDE"); }} 

				 ///<summary>英镑</summary>
 				  public static string GeneralLogic_enUK{
 				  get { return LangUtilities.GetString( "GeneralLogic_enUK"); }} 

				 ///<summary>美元</summary>
 				  public static string GeneralLogic_enUS{
 				  get { return LangUtilities.GetString( "GeneralLogic_enUS"); }} 

				 ///<summary>日元</summary>
 				  public static string GeneralLogic_jpJP{
 				  get { return LangUtilities.GetString( "GeneralLogic_jpJP"); }} 

				 ///<summary>卢布</summary>
 				  public static string GeneralLogic_ruRU{
 				  get { return LangUtilities.GetString( "GeneralLogic_ruRU"); }} 

				 ///<summary>港币</summary>
 				  public static string GeneralLogic_zhHK{
 				  get { return LangUtilities.GetString( "GeneralLogic_zhHK"); }} 

				 ///<summary>確認</summary>
 				  public static string GeneralUI_Comfirm{
 				  get { return LangUtilities.GetString( "GeneralUI_Comfirm"); }} 

				 ///<summary>出错了~~</summary>
 				  public static string GeneralUI_Fail{
 				  get { return LangUtilities.GetString( "GeneralUI_Fail"); }} 

				 ///<summary>忘记密码？</summary>
 				  public static string GeneralUI_ForgotPassword{
 				  get { return LangUtilities.GetString( "GeneralUI_ForgotPassword"); }} 

				 ///<summary>I see</summary>
 				  public static string GeneralUI_Isee{
 				  get { return LangUtilities.GetString( "GeneralUI_Isee"); }} 

				 ///<summary>登 录</summary>
 				  public static string GeneralUI_Login{
 				  get { return LangUtilities.GetString( "GeneralUI_Login"); }} 

				 ///<summary>注 销</summary>
 				  public static string GeneralUI_LogOut{
 				  get { return LangUtilities.GetString( "GeneralUI_LogOut"); }} 

				 ///<summary>OK</summary>
 				  public static string GeneralUI_OK{
 				  get { return LangUtilities.GetString( "GeneralUI_OK"); }} 

				 ///<summary>第{0}页，共{1}页 每页{2}条</summary>
 				  public static string GeneralUI_PagerInfo{
 				  get { return LangUtilities.GetString( "GeneralUI_PagerInfo"); }} 

				 ///<summary>记 录</summary>
 				  public static string GeneralUI_Record{
 				  get { return LangUtilities.GetString( "GeneralUI_Record"); }} 

				 ///<summary>注 册</summary>
 				  public static string GeneralUI_Registration{
 				  get { return LangUtilities.GetString( "GeneralUI_Registration"); }} 

				 ///<summary>返回结果</summary>
 				  public static string GeneralUI_ReturnResult{
 				  get { return LangUtilities.GetString( "GeneralUI_ReturnResult"); }} 

				 ///<summary>选择</summary>
 				  public static string GeneralUI_Select{
 				  get { return LangUtilities.GetString( "GeneralUI_Select"); }} 

				 ///<summary>选择文件</summary>
 				  public static string GeneralUI_SelectFile{
 				  get { return LangUtilities.GetString( "GeneralUI_SelectFile"); }} 

				 ///<summary>来源</summary>
 				  public static string GeneralUI_Source{
 				  get { return LangUtilities.GetString( "GeneralUI_Source"); }} 

				 ///<summary>参考ID</summary>
 				  public static string GeneralUI_TblKeyId{
 				  get { return LangUtilities.GetString( "GeneralUI_TblKeyId"); }} 

				 ///<summary>人民币</summary>
 				  public static string GeneralUI_zhCN{
 				  get { return LangUtilities.GetString( "GeneralUI_zhCN"); }} 

				 ///<summary>考勤与薪酬系统</summary>
 				  public static string HELP_FUNCTUON_DATAGUARD{
 				  get { return LangUtilities.GetString( "HELP_FUNCTUON_DATAGUARD"); }} 

				 ///<summary>相关业务</summary>
 				  public static string Home_DefinitedTag_BusinessKeyWord{
 				  get { return LangUtilities.GetString( "Home_DefinitedTag_BusinessKeyWord"); }} 

				 ///<summary>案例支持</summary>
 				  public static string Home_DefinitedTag_CaseSupport{
 				  get { return LangUtilities.GetString( "Home_DefinitedTag_CaseSupport"); }} 

				 ///<summary>本网內容关键词</summary>
 				  public static string Home_DefinitedTag_KeyWord{
 				  get { return LangUtilities.GetString( "Home_DefinitedTag_KeyWord"); }} 

				 ///<summary>SuperX & Accapi</summary>
 				  public static string Home_Index_Description{
 				  get { return LangUtilities.GetString( "Home_Index_Description"); }} 

				 ///<summary>SuperX & Accapi</summary>
 				  public static string Home_Index_KeyWord{
 				  get { return LangUtilities.GetString( "Home_Index_KeyWord"); }} 

				 ///<summary>SuperX & Accapi</summary>
 				  public static string Home_Index_Title{
 				  get { return LangUtilities.GetString( "Home_Index_Title"); }} 

				 ///<summary>确定填入的资料</summary>
 				  public static string HomeShopIndex2_Views_ConfirmInfo{
 				  get { return LangUtilities.GetString( "HomeShopIndex2_Views_ConfirmInfo"); }} 

				 ///<summary>货号</summary>
 				  public static string HomeShopIndex2_Views_DefinitedUI_StyleNo{
 				  get { return LangUtilities.GetString( "HomeShopIndex2_Views_DefinitedUI_StyleNo"); }} 

				 ///<summary>无效数据成功删除</summary>
 				  public static string Info_ClearInvalidData_msg{
 				  get { return LangUtilities.GetString( "Info_ClearInvalidData_msg"); }} 

				 ///<summary>程序出错,操作失败</summary>
 				  public static string Info_ClearInvalidData_msgError{
 				  get { return LangUtilities.GetString( "Info_ClearInvalidData_msgError"); }} 

				 ///<summary><br/><h3>相关文档，成功删除</h3><br/>UploadItemId=</summary>
 				  public static string Info_DeleteUploadItem_msg1{
 				  get { return LangUtilities.GetString( "Info_DeleteUploadItem_msg1"); }} 

				 ///<summary><br>数据记录已经删除，但不存在相关文件。</summary>
 				  public static string Info_DeleteUploadItem_msg2{
 				  get { return LangUtilities.GetString( "Info_DeleteUploadItem_msg2"); }} 

				 ///<summary><br/><h3>程序出错,操作失败</h3><br/></summary>
 				  public static string Info_DeleteUploadItem_msg3{
 				  get { return LangUtilities.GetString( "Info_DeleteUploadItem_msg3"); }} 

				 ///<summary>整理无效数据</summary>
 				  public static string Info_InfoIPstatitics_ClearInvalidData_Content{
 				  get { return LangUtilities.GetString( "Info_InfoIPstatitics_ClearInvalidData_Content"); }} 

				 ///<summary>整理无效数据-返回成功 :</summary>
 				  public static string Info_InfoIPstatitics_ClearInvalidData_Title{
 				  get { return LangUtilities.GetString( "Info_InfoIPstatitics_ClearInvalidData_Title"); }} 

				 ///<summary>用户阅读页面的累计时间，单位分钟</summary>
 				  public static string Info_InfoIPstatitics_Duration_ToolTips{
 				  get { return LangUtilities.GetString( "Info_InfoIPstatitics_Duration_ToolTips"); }} 

				 ///<summary>页面加载所用的时间</summary>
 				  public static string Info_InfoIPstatitics_LoadTime_ToolTips{
 				  get { return LangUtilities.GetString( "Info_InfoIPstatitics_LoadTime_ToolTips"); }} 

				 ///<summary>传入参数错误</summary>
 				  public static string Info_RetriveSeoExtandNodeHtml5_msg{
 				  get { return LangUtilities.GetString( "Info_RetriveSeoExtandNodeHtml5_msg"); }} 

				 ///<summary>更新数据失败</summary>
 				  public static string Info_SeoHtmlContextAdd_Message_UpdateFail{
 				  get { return LangUtilities.GetString( "Info_SeoHtmlContextAdd_Message_UpdateFail"); }} 

				 ///<summary>更新数据成功</summary>
 				  public static string Info_SeoHtmlContextAdd_Message_UpdateSucc{
 				  get { return LangUtilities.GetString( "Info_SeoHtmlContextAdd_Message_UpdateSucc"); }} 

				 ///<summary>通用资讯类</summary>
 				  public static string INFOCATE_COMMON_INFO{
 				  get { return LangUtilities.GetString( "INFOCATE_COMMON_INFO"); }} 

				 ///<summary>分类ID</summary>
 				  public static string InfoCate_InfoCateID{
 				  get { return LangUtilities.GetString( "InfoCate_InfoCateID"); }} 

				 ///<summary>信息分类名</summary>
 				  public static string InfoCate_InfoCateName{
 				  get { return LangUtilities.GetString( "InfoCate_InfoCateName"); }} 

				 ///<summary>语言代码</summary>
 				  public static string InfoCate_LanguageCode{
 				  get { return LangUtilities.GetString( "InfoCate_LanguageCode"); }} 

				 ///<summary>分层</summary>
 				  public static string InfoCate_Levels{
 				  get { return LangUtilities.GetString( "InfoCate_Levels"); }} 

				 ///<summary>操作日期</summary>
 				  public static string InfoCate_OperatedDate{
 				  get { return LangUtilities.GetString( "InfoCate_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string InfoCate_OperatedUserName{
 				  get { return LangUtilities.GetString( "InfoCate_OperatedUserName"); }} 

				 ///<summary>父信息类</summary>
 				  public static string InfoCate_PrarentsID{
 				  get { return LangUtilities.GetString( "InfoCate_PrarentsID"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string InfoCate_ShopID{
 				  get { return LangUtilities.GetString( "InfoCate_ShopID"); }} 

				 ///<summary>AI-BOX目标识别盒子</summary>
 				  public static string INFOCATE_SOFTWARE_HELPER_AIBOX{
 				  get { return LangUtilities.GetString( "INFOCATE_SOFTWARE_HELPER_AIBOX"); }} 

				 ///<summary>AI GUARD 大廈智能管理系統</summary>
 				  public static string INFOCATE_SOFTWARE_HELPER_AIGUARD{
 				  get { return LangUtilities.GetString( "INFOCATE_SOFTWARE_HELPER_AIGUARD"); }} 

				 ///<summary>作者</summary>
 				  public static string InfoDetail_Author{
 				  get { return LangUtilities.GetString( "InfoDetail_Author"); }} 

				 ///<summary>创建日期</summary>
 				  public static string InfoDetail_CreatedDate{
 				  get { return LangUtilities.GetString( "InfoDetail_CreatedDate"); }} 

				 ///<summary>编辑</summary>
 				  public static string InfoDetail_Editor{
 				  get { return LangUtilities.GetString( "InfoDetail_Editor"); }} 

				 ///<summary>信息分类</summary>
 				  public static string InfoDetail_InfoCateID{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoCateID"); }} 

				 ///<summary>描述</summary>
 				  public static string InfoDetail_InfoDescription{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoDescription"); }} 

				 ///<summary>适合资讯项模板</summary>
 				  public static string InfoDetail_InfoDetail_InfoItemTemplateIDs{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoDetail_InfoItemTemplateIDs"); }} 

				 ///<summary>InfoID</summary>
 				  public static string InfoDetail_InfoID{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoID"); }} 

				 ///<summary>适合资讯项模板</summary>
 				  public static string InfoDetail_InfoItemTemplateIDs{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoItemTemplateIDs"); }} 

				 ///<summary>互联 规划研究 理财云知识知识优化</summary>
 				  public static string InfoDetail_InfoList_KeyWordDescription{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoList_KeyWordDescription"); }} 

				 ///<summary>信汇规划研究 云知识知识优化</summary>
 				  public static string InfoDetail_InfoList_KeyWords{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoList_KeyWords"); }} 

				 ///<summary>资讯</summary>
 				  public static string InfoDetail_InfoList_Title{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoList_Title"); }} 

				 ///<summary>跟踪ID</summary>
 				  public static string InfoDetail_InfoTraceID{
 				  get { return LangUtilities.GetString( "InfoDetail_InfoTraceID"); }} 

				 ///<summary>原创</summary>
 				  public static string InfoDetail_IsOriginal{
 				  get { return LangUtilities.GetString( "InfoDetail_IsOriginal"); }} 

				 ///<summary>语言标识</summary>
 				  public static string InfoDetail_LanguageCode{
 				  get { return LangUtilities.GetString( "InfoDetail_LanguageCode"); }} 

				 ///<summary>外语需要标识,繁体和简体是自动转换,选择无设置(NO SET)</summary>
 				  public static string InfoDetail_LanguageCodeTips{
 				  get { return LangUtilities.GetString( "InfoDetail_LanguageCodeTips"); }} 

				 ///<summary>操作日期</summary>
 				  public static string InfoDetail_OperatedDate{
 				  get { return LangUtilities.GetString( "InfoDetail_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string InfoDetail_OperatedUserName{
 				  get { return LangUtilities.GetString( "InfoDetail_OperatedUserName"); }} 

				 ///<summary>SEO描述</summary>
 				  public static string InfoDetail_SeoDescription{
 				  get { return LangUtilities.GetString( "InfoDetail_SeoDescription"); }} 

				 ///<summary>SEO关键词</summary>
 				  public static string InfoDetail_SeoKeyword{
 				  get { return LangUtilities.GetString( "InfoDetail_SeoKeyword"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string InfoDetail_ShopID{
 				  get { return LangUtilities.GetString( "InfoDetail_ShopID"); }} 

				 ///<summary>员工ID</summary>
 				  public static string InfoDetail_ShopStaffID{
 				  get { return LangUtilities.GetString( "InfoDetail_ShopStaffID"); }} 

				 ///<summary>标题图显示</summary>
 				  public static string InfoDetail_ShowTitleThumbNail{
 				  get { return LangUtilities.GetString( "InfoDetail_ShowTitleThumbNail"); }} 

				 ///<summary>副标题</summary>
 				  public static string InfoDetail_SubTitle{
 				  get { return LangUtilities.GetString( "InfoDetail_SubTitle"); }} 

				 ///<summary>标题</summary>
 				  public static string InfoDetail_Title{
 				  get { return LangUtilities.GetString( "InfoDetail_Title"); }} 

				 ///<summary>标题图</summary>
 				  public static string InfoDetail_TitleThumbNail{
 				  get { return LangUtilities.GetString( "InfoDetail_TitleThumbNail"); }} 

				 ///<summary>视频连接</summary>
 				  public static string InfoDetail_VideoUrl{
 				  get { return LangUtilities.GetString( "InfoDetail_VideoUrl"); }} 

				 ///<summary>浏览</summary>
 				  public static string InfoDetail_Views{
 				  get { return LangUtilities.GetString( "InfoDetail_Views"); }} 

				 ///<summary>IP来源统计</summary>
 				  public static string InfoIPstatitics_SubTitle{
 				  get { return LangUtilities.GetString( "InfoIPstatitics_SubTitle"); }} 

				 ///<summary>信息统计</summary>
 				  public static string InfoIPstatitics_Title{
 				  get { return LangUtilities.GetString( "InfoIPstatitics_Title"); }} 

				 ///<summary>资讯项模板ID</summary>
 				  public static string InfoItemTemplate_InfoItemTemplateID{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_InfoItemTemplateID"); }} 

				 ///<summary>资讯项模板名称</summary>
 				  public static string InfoItemTemplate_InfoItemTemplateName{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_InfoItemTemplateName"); }} 

				 ///<summary>操作日期</summary>
 				  public static string InfoItemTemplate_OperatedDate{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string InfoItemTemplate_OperatedUserName{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_OperatedUserName"); }} 

				 ///<summary>路径</summary>
 				  public static string InfoItemTemplate_Path{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_Path"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string InfoItemTemplate_ShopID{
 				  get { return LangUtilities.GetString( "InfoItemTemplate_ShopID"); }} 

				 ///<summary>导读</summary>
 				  public static string InfoList_InfoDetails_DefinitedTag_Introduction{
 				  get { return LangUtilities.GetString( "InfoList_InfoDetails_DefinitedTag_Introduction"); }} 

				 ///<summary>推荐阅读</summary>
 				  public static string InfoList_InfoDetails_DefinitedTag_RelateInfo{
 				  get { return LangUtilities.GetString( "InfoList_InfoDetails_DefinitedTag_RelateInfo"); }} 

				 ///<summary>行业动态</summary>
 				  public static string InfoList_InfoDetailsIndustryDynamic{
 				  get { return LangUtilities.GetString( "InfoList_InfoDetailsIndustryDynamic"); }} 

				 ///<summary>发布</summary>
 				  public static string InfoList_InfoListUnit_DefinitedTag_Author{
 				  get { return LangUtilities.GetString( "InfoList_InfoListUnit_DefinitedTag_Author"); }} 

				 ///<summary>评论:</summary>
 				  public static string InfoList_InfoListUnit_DefinitedTag_Comment{
 				  get { return LangUtilities.GetString( "InfoList_InfoListUnit_DefinitedTag_Comment"); }} 

				 ///<summary>资讯管理</summary>
 				  public static string InfoListView_SubTitle{
 				  get { return LangUtilities.GetString( "InfoListView_SubTitle"); }} 

				 ///<summary>资讯列表</summary>
 				  public static string InfoListView_Title{
 				  get { return LangUtilities.GetString( "InfoListView_Title"); }} 

				 ///<summary>拉黑手机名单</summary>
 				  public static string IsBlockPhoneNumber_Boxtitle{
 				  get { return LangUtilities.GetString( "IsBlockPhoneNumber_Boxtitle"); }} 

				 ///<summary>内部代码遇到错误,函数</summary>
 				  public static string IsBlockPhoneNumber_JS_Boxtitle{
 				  get { return LangUtilities.GetString( "IsBlockPhoneNumber_JS_Boxtitle"); }} 

				 ///<summary>回调结果</summary>
 				  public static string JS_Savechanges_upd_PropertiesValueName_callbackResult{
 				  get { return LangUtilities.GetString( "JS_Savechanges_upd_PropertiesValueName_callbackResult"); }} 

				 ///<summary>阿拉伯语</summary>
 				  public static string Language_ar{
 				  get { return LangUtilities.GetString( "Language_ar"); }} 

				 ///<summary>德语</summary>
 				  public static string Language_de{
 				  get { return LangUtilities.GetString( "Language_de"); }} 

				 ///<summary>英语</summary>
 				  public static string Language_en{
 				  get { return LangUtilities.GetString( "Language_en"); }} 

				 ///<summary>西班牙</summary>
 				  public static string Language_es{
 				  get { return LangUtilities.GetString( "Language_es"); }} 

				 ///<summary>法语</summary>
 				  public static string Language_fr{
 				  get { return LangUtilities.GetString( "Language_fr"); }} 

				 ///<summary>日本語</summary>
 				  public static string Language_ja{
 				  get { return LangUtilities.GetString( "Language_ja"); }} 

				 ///<summary>类型</summary>
 				  public static string Language_KeyType{
 				  get { return LangUtilities.GetString( "Language_KeyType"); }} 

				 ///<summary>韓國語</summary>
 				  public static string Language_ko{
 				  get { return LangUtilities.GetString( "Language_ko"); }} 

				 ///<summary>语言标识无设置</summary>
 				  public static string Language_NOSET{
 				  get { return LangUtilities.GetString( "Language_NOSET"); }} 

				 ///<summary>Remarks</summary>
 				  public static string Language_Remarks{
 				  get { return LangUtilities.GetString( "Language_Remarks"); }} 

				 ///<summary>俄语</summary>
 				  public static string Language_ru{
 				  get { return LangUtilities.GetString( "Language_ru"); }} 

				 ///<summary>华语繁体</summary>
 				  public static string Language_zh{
 				  get { return LangUtilities.GetString( "Language_zh"); }} 

				 ///<summary>简体中文</summary>
 				  public static string Language_zh_CN{
 				  get { return LangUtilities.GetString( "Language_zh_CN"); }} 

				 ///<summary>香港繁体</summary>
 				  public static string Language_zh_HK{
 				  get { return LangUtilities.GetString( "Language_zh_HK"); }} 

				 ///<summary>下载Text通讯录</summary>
 				  public static string LoadAccountDownLog_TextTitle{
 				  get { return LangUtilities.GetString( "LoadAccountDownLog_TextTitle"); }} 

				 ///<summary>帐号资源下载列表</summary>
 				  public static string LoadAccountDownLog_Title{
 				  get { return LangUtilities.GetString( "LoadAccountDownLog_Title"); }} 

				 ///<summary>下载Vcard通讯录</summary>
 				  public static string LoadAccountDownLog_VcardTitle{
 				  get { return LangUtilities.GetString( "LoadAccountDownLog_VcardTitle"); }} 

				 ///<summary>验证码无效,请换一换</summary>
 				  public static string Manage_AddPhoneNumber_AddModelError1{
 				  get { return LangUtilities.GetString( "Manage_AddPhoneNumber_AddModelError1"); }} 

				 ///<summary>换一换</summary>
 				  public static string Manage_AddPhoneNumber_DefinitedTag_ChangeCode{
 				  get { return LangUtilities.GetString( "Manage_AddPhoneNumber_DefinitedTag_ChangeCode"); }} 

				 ///<summary>手机号码验证</summary>
 				  public static string Manage_AddPhoneNumber_Title{
 				  get { return LangUtilities.GetString( "Manage_AddPhoneNumber_Title"); }} 

				 ///<summary>更改密码</summary>
 				  public static string Manage_ChangePassword_ChangePassword{
 				  get { return LangUtilities.GetString( "Manage_ChangePassword_ChangePassword"); }} 

				 ///<summary>更改密码</summary>
 				  public static string Manage_ChangePassword_DefinitedTag_BoxTitleChangePassword{
 				  get { return LangUtilities.GetString( "Manage_ChangePassword_DefinitedTag_BoxTitleChangePassword"); }} 

				 ///<summary>更改密码</summary>
 				  public static string Manage_ChangePassword_Title{
 				  get { return LangUtilities.GetString( "Manage_ChangePassword_Title"); }} 

				 ///<summary>店铺LOGO</summary>
 				  public static string Manage_CreateShop__DefinitedTag_ShopLogo{
 				  get { return LangUtilities.GetString( "Manage_CreateShop__DefinitedTag_ShopLogo"); }} 

				 ///<summary>我的店铺</summary>
 				  public static string Manage_CreateShop_Title{
 				  get { return LangUtilities.GetString( "Manage_CreateShop_Title"); }} 

				 ///<summary>返回更改</summary>
 				  public static string Manage_CreateShopReturn_DefinitedTag_ReturnToModify{
 				  get { return LangUtilities.GetString( "Manage_CreateShopReturn_DefinitedTag_ReturnToModify"); }} 

				 ///<summary>查看我的店铺</summary>
 				  public static string Manage_CreateShopReturn_DefinitedTag_ViewMyShop{
 				  get { return LangUtilities.GetString( "Manage_CreateShopReturn_DefinitedTag_ViewMyShop"); }} 

				 ///<summary>添加手机</summary>
 				  public static string Manage_Index_DefinitedTag_AddMobile{
 				  get { return LangUtilities.GetString( "Manage_Index_DefinitedTag_AddMobile"); }} 

				 ///<summary>手机验证保护:</summary>
 				  public static string Manage_Index_DefinitedTag_AddMobileProtected{
 				  get { return LangUtilities.GetString( "Manage_Index_DefinitedTag_AddMobileProtected"); }} 

				 ///<summary>已添加你的手机号码。</summary>
 				  public static string Manage_Index_message_AddPhoneSuccess{
 				  get { return LangUtilities.GetString( "Manage_Index_message_AddPhoneSuccess"); }} 

				 ///<summary>已更改你的密码。</summary>
 				  public static string Manage_Index_message_ChangePasswordSuccess{
 				  get { return LangUtilities.GetString( "Manage_Index_message_ChangePasswordSuccess"); }} 

				 ///<summary>出现错误。</summary>
 				  public static string Manage_Index_message_Error{
 				  get { return LangUtilities.GetString( "Manage_Index_message_Error"); }} 

				 ///<summary>已删除你的电话号码。</summary>
 				  public static string Manage_Index_message_RemovePhoneSuccess{
 				  get { return LangUtilities.GetString( "Manage_Index_message_RemovePhoneSuccess"); }} 

				 ///<summary>已设置你的密码。</summary>
 				  public static string Manage_Index_message_SetPasswordSuccess{
 				  get { return LangUtilities.GetString( "Manage_Index_message_SetPasswordSuccess"); }} 

				 ///<summary>已设置你的双重身份验证提供程序。</summary>
 				  public static string Manage_Index_message_SetTwoFactorSuccess{
 				  get { return LangUtilities.GetString( "Manage_Index_message_SetTwoFactorSuccess"); }} 

				 ///<summary>帐户安全设置</summary>
 				  public static string Manage_Index_Title{
 				  get { return LangUtilities.GetString( "Manage_Index_Title"); }} 

				 ///<summary>出现错误。</summary>
 				  public static string Manage_ManageLogins_ManageMessageId_Error{
 				  get { return LangUtilities.GetString( "Manage_ManageLogins_ManageMessageId_Error"); }} 

				 ///<summary>已删除外部登录名。</summary>
 				  public static string Manage_ManageLogins_ManageMessageId_RemoveLoginSuccess{
 				  get { return LangUtilities.GetString( "Manage_ManageLogins_ManageMessageId_RemoveLoginSuccess"); }} 

				 ///<summary>创建本地登录名</summary>
 				  public static string Manage_SetPassword_BoxTitle{
 				  get { return LangUtilities.GetString( "Manage_SetPassword_BoxTitle"); }} 

				 ///<summary>你沒有此站点的本地用户名/密码。请添加一个本地帐户，这样，无需外部登录名即可登录。</summary>
 				  public static string Manage_SetPassword_DefinitedTag_PDesc{
 				  get { return LangUtilities.GetString( "Manage_SetPassword_DefinitedTag_PDesc"); }} 

				 ///<summary>创建密码</summary>
 				  public static string Manage_SetPassword_Title{
 				  get { return LangUtilities.GetString( "Manage_SetPassword_Title"); }} 

				 ///<summary>无法手机验证码</summary>
 				  public static string Manage_VerifyPhoneNumber_AddModelError1{
 				  get { return LangUtilities.GetString( "Manage_VerifyPhoneNumber_AddModelError1"); }} 

				 ///<summary>请查阅手机短信获取</summary>
 				  public static string Manage_VerifyPhoneNumber_DefinitedTag_placeholder{
 				  get { return LangUtilities.GetString( "Manage_VerifyPhoneNumber_DefinitedTag_placeholder"); }} 

				 ///<summary>重新输入手机号</summary>
 				  public static string Manage_VerifyPhoneNumber_DefinitedTag_Title{
 				  get { return LangUtilities.GetString( "Manage_VerifyPhoneNumber_DefinitedTag_Title"); }} 

				 ///<summary>手机验证码已经发送</summary>
 				  public static string Manage_VerifyPhoneNumber_Title{
 				  get { return LangUtilities.GetString( "Manage_VerifyPhoneNumber_Title"); }} 

				 ///<summary><br/><h4>菜单及其子节点成功删除</h4><br/></summary>
 				  public static string ManuItem_ActionMethod_Del{
 				  get { return LangUtilities.GetString( "ManuItem_ActionMethod_Del"); }} 

				 ///<summary>查询不存在</summary>
 				  public static string ManuItem_ActionMethod_Delete_NotExists{
 				  get { return LangUtilities.GetString( "ManuItem_ActionMethod_Delete_NotExists"); }} 

				 ///<summary><br/><h4>程序出错,操作失败</h4><br/></summary>
 				  public static string ManuItem_ActionMethod_DeleteMenuItem_Failure{
 				  get { return LangUtilities.GetString( "ManuItem_ActionMethod_DeleteMenuItem_Failure"); }} 

				 ///<summary>菜单名称</summary>
 				  public static string MenuItem_EngMenuItemName{
 				  get { return LangUtilities.GetString( "MenuItem_EngMenuItemName"); }} 

				 ///<summary>角色授权</summary>
 				  public static string MenuItem_ForRoleName{
 				  get { return LangUtilities.GetString( "MenuItem_ForRoleName"); }} 

				 ///<summary>菜单ID</summary>
 				  public static string MenuItem_MenuItemID{
 				  get { return LangUtilities.GetString( "MenuItem_MenuItemID"); }} 

				 ///<summary>菜单名称</summary>
 				  public static string MenuItem_MenuItemName{
 				  get { return LangUtilities.GetString( "MenuItem_MenuItemName"); }} 

				 ///<summary>连接</summary>
 				  public static string MenuItem_MenuLink{
 				  get { return LangUtilities.GetString( "MenuItem_MenuLink"); }} 

				 ///<summary>操作日期</summary>
 				  public static string MenuItem_OperatedDate{
 				  get { return LangUtilities.GetString( "MenuItem_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string MenuItem_OperatedUserName{
 				  get { return LangUtilities.GetString( "MenuItem_OperatedUserName"); }} 

				 ///<summary>父菜单ID</summary>
 				  public static string MenuItem_ParentsMenuItemID{
 				  get { return LangUtilities.GetString( "MenuItem_ParentsMenuItemID"); }} 

				 ///<summary>打开方式</summary>
 				  public static string MenuItem_Target{
 				  get { return LangUtilities.GetString( "MenuItem_Target"); }} 

				 ///<summary>客户关系管理 Role:StoreAdmin</summary>
 				  public static string MgrUser_Index_SubTitle{
 				  get { return LangUtilities.GetString( "MgrUser_Index_SubTitle"); }} 

				 ///<summary>会员列表</summary>
 				  public static string MgrUser_Index_Title{
 				  get { return LangUtilities.GetString( "MgrUser_Index_Title"); }} 

				 ///<summary>字体大小</summary>
 				  public static string Modal_FontSize{
 				  get { return LangUtilities.GetString( "Modal_FontSize"); }} 

				 ///<summary>限制宽度</summary>
 				  public static string Modal_MaxWidth{
 				  get { return LangUtilities.GetString( "Modal_MaxWidth"); }} 

				 ///<summary>请输入量化因子模拟分值（1-99,建议百分制）。</summary>
 				  public static string Modal_Score_ErrorMessage{
 				  get { return LangUtilities.GetString( "Modal_Score_ErrorMessage"); }} 

				 ///<summary>标签ID</summary>
 				  public static string Modal_TemplateNotePositionId{
 				  get { return LangUtilities.GetString( "Modal_TemplateNotePositionId"); }} 

				 ///<summary>账号管理</summary>
 				  public static string ModalView_AccountMgrAddOrUpd_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_AccountMgrAddOrUpd_SubTitle"); }} 

				 ///<summary>授权多个用户使用</summary>
 				  public static string ModalView_AccountMgrAddOrUpd_Table_Tooltip{
 				  get { return LangUtilities.GetString( "ModalView_AccountMgrAddOrUpd_Table_Tooltip"); }} 

				 ///<summary>新增属性值</summary>
 				  public static string ModalView_AddAttribute_Create{
 				  get { return LangUtilities.GetString( "ModalView_AddAttribute_Create"); }} 

				 ///<summary>请把获取的HTML5模板复制粘贴到描述HTML5编辑器</summary>
 				  public static string ModalView_AddUpdateInfo_bg_black_gradient_text{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_bg_black_gradient_text"); }} 

				 ///<summary>附加HTML5</summary>
 				  public static string ModalView_AddUpdateInfo_btn_append1_text{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_btn_append1_text"); }} 

				 ///<summary>点击此处变更标题图片</summary>
 				  public static string ModalView_AddUpdateInfo_ClktoChangePicture{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_ClktoChangePicture"); }} 

				 ///<summary>是否在内容中首先显示标题图</summary>
 				  public static string ModalView_AddUpdateInfo_IsDisplayTitlePic{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_IsDisplayTitlePic"); }} 

				 ///<summary>相关的图片和视频</summary>
 				  public static string ModalView_AddUpdateInfo_ModalSeoHtml_myModalLabel_UploadItem{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_ModalSeoHtml_myModalLabel_UploadItem"); }} 

				 ///<summary>关键词富文本HTML5模板</summary>
 				  public static string ModalView_AddUpdateInfo_ModalSeoHtml_Title_text{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_ModalSeoHtml_Title_text"); }} 

				 ///<summary>信息资讯记录成功删除</summary>
 				  public static string ModalView_AddUpdateInfo_Msg{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_Msg"); }} 

				 ///<summary>信息发布系统</summary>
 				  public static string ModalView_AddUpdateInfo_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_AddUpdateInfo_SubTitle"); }} 

				 ///<summary>证书密码</summary>
 				  public static string ModalView_CerPassword_Title{
 				  get { return LangUtilities.GetString( "ModalView_CerPassword_Title"); }} 

				 ///<summary>复利终值</summary>
 				  public static string ModalView_CompoundInterestView_F{
 				  get { return LangUtilities.GetString( "ModalView_CompoundInterestView_F"); }} 

				 ///<summary>利率</summary>
 				  public static string ModalView_CompoundInterestView_i{
 				  get { return LangUtilities.GetString( "ModalView_CompoundInterestView_i"); }} 

				 ///<summary>年期</summary>
 				  public static string ModalView_CompoundInterestView_n{
 				  get { return LangUtilities.GetString( "ModalView_CompoundInterestView_n"); }} 

				 ///<summary>复利初值</summary>
 				  public static string ModalView_CompoundInterestView_P{
 				  get { return LangUtilities.GetString( "ModalView_CompoundInterestView_P"); }} 

				 ///<summary>活动时间</summary>
 				  public static string ModalView_CouponAddOrUpd_ActivityTime{
 				  get { return LangUtilities.GetString( "ModalView_CouponAddOrUpd_ActivityTime"); }} 

				 ///<summary>优惠券列表</summary>
 				  public static string ModalView_CouponAddOrUpd_Title{
 				  get { return LangUtilities.GetString( "ModalView_CouponAddOrUpd_Title"); }} 

				 ///<summary>关键词管理</summary>
 				  public static string ModalView_KeywordMgr{
 				  get { return LangUtilities.GetString( "ModalView_KeywordMgr"); }} 

				 ///<summary>键 名</summary>
 				  public static string ModalView_LangDetail_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_LangDetail_SubTitle"); }} 

				 ///<summary>更 新</summary>
 				  public static string ModalView_LangDetail_Title{
 				  get { return LangUtilities.GetString( "ModalView_LangDetail_Title"); }} 

				 ///<summary>输入URL,没有则输入‘#’</summary>
 				  public static string ModalView_MenuItem_Create{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_Create"); }} 

				 ///<summary>删除菜单及其子节点∷</summary>
 				  public static string ModalView_MenuItem_Create_DeleteMenuNodes{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_Create_DeleteMenuNodes"); }} 

				 ///<summary>创建菜单</summary>
 				  public static string ModalView_MenuItem_Create_Span0{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_Create_Span0"); }} 

				 ///<summary>英文菜单名称</summary>
 				  public static string ModalView_MenuItem_EngMenuItemName{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_EngMenuItemName"); }} 

				 ///<summary>多语言列表</summary>
 				  public static string ModalView_MenuItem_LangList_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_LangList_SubTitle"); }} 

				 ///<summary>多语言管理</summary>
 				  public static string ModalView_MenuItem_LangList_Title{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_LangList_Title"); }} 

				 ///<summary>菜单名称</summary>
 				  public static string ModalView_MenuItem_MenuItemName{
 				  get { return LangUtilities.GetString( "ModalView_MenuItem_MenuItemName"); }} 

				 ///<summary>后台管理主界面</summary>
 				  public static string ModalView_Mgr_Index_MainInterface{
 				  get { return LangUtilities.GetString( "ModalView_Mgr_Index_MainInterface"); }} 

				 ///<summary>管理列表</summary>
 				  public static string ModalView_Mgrlist{
 				  get { return LangUtilities.GetString( "ModalView_Mgrlist"); }} 

				 ///<summary>类目名称</summary>
 				  public static string ModalView_ProdCateV2_Index_CategoryName{
 				  get { return LangUtilities.GetString( "ModalView_ProdCateV2_Index_CategoryName"); }} 

				 ///<summary>属性名称</summary>
 				  public static string ModalView_ProdCateV2_Index_PropertyName{
 				  get { return LangUtilities.GetString( "ModalView_ProdCateV2_Index_PropertyName"); }} 

				 ///<summary>属性值新增</summary>
 				  public static string ModalView_ProductPropertiesValue_Create_Title_AttributeAdd{
 				  get { return LangUtilities.GetString( "ModalView_ProductPropertiesValue_Create_Title_AttributeAdd"); }} 

				 ///<summary>确定删除吗？</summary>
 				  public static string ModalView_ProductPropertiesValue_Delete_Sure{
 				  get { return LangUtilities.GetString( "ModalView_ProductPropertiesValue_Delete_Sure"); }} 

				 ///<summary>删除属性值会影响商品类目属性的完整性！\n\r确定删除吗？</summary>
 				  public static string ModalView_ProductPropertiesValue_Delete_Sure2{
 				  get { return LangUtilities.GetString( "ModalView_ProductPropertiesValue_Delete_Sure2"); }} 

				 ///<summary>查询关键词</summary>
 				  public static string ModalView_QryKeyword{
 				  get { return LangUtilities.GetString( "ModalView_QryKeyword"); }} 

				 ///<summary>随机100个</summary>
 				  public static string ModalView_RenderAmountUnit100{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit100"); }} 

				 ///<summary>随机1500个</summary>
 				  public static string ModalView_RenderAmountUnit1500{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit1500"); }} 

				 ///<summary>随机200个</summary>
 				  public static string ModalView_RenderAmountUnit200{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit200"); }} 

				 ///<summary>随机2000个</summary>
 				  public static string ModalView_RenderAmountUnit2000{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit2000"); }} 

				 ///<summary>随机50个</summary>
 				  public static string ModalView_RenderAmountUnit50{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit50"); }} 

				 ///<summary>随机500个</summary>
 				  public static string ModalView_RenderAmountUnit500{
 				  get { return LangUtilities.GetString( "ModalView_RenderAmountUnit500"); }} 

				 ///<summary>删除当前所选的关键词</summary>
 				  public static string ModalView_SeoHtmlContextAdd_DelCurKeyWord{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_DelCurKeyWord"); }} 

				 ///<summary>查询父级关键词</summary>
 				  public static string ModalView_SeoHtmlContextAdd_Queryparentkeywords{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_Queryparentkeywords"); }} 

				 ///<summary>SEO优化关键词</summary>
 				  public static string ModalView_SeoHtmlContextAdd_SEOKeyWord{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_SEOKeyWord"); }} 

				 ///<summary>內容、文檔等等</summary>
 				  public static string ModalView_SeoHtmlContextAdd_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_SubTitle"); }} 

				 ///<summary>知识积累库</summary>
 				  public static string ModalView_SeoHtmlContextAdd_Title{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_Title"); }} 

				 ///<summary>更新知识积累库</summary>
 				  public static string ModalView_SeoHtmlContextAdd_Title2{
 				  get { return LangUtilities.GetString( "ModalView_SeoHtmlContextAdd_Title2"); }} 

				 ///<summary>菜单管理</summary>
 				  public static string ModalView_SubTitle{
 				  get { return LangUtilities.GetString( "ModalView_SubTitle"); }} 

				 ///<summary>店铺供应商列表</summary>
 				  public static string ModalView_SupplierAddOrUpd_Title{
 				  get { return LangUtilities.GetString( "ModalView_SupplierAddOrUpd_Title"); }} 

				 ///<summary>供应商列表</summary>
 				  public static string ModalView_Supplierlist{
 				  get { return LangUtilities.GetString( "ModalView_Supplierlist"); }} 

				 ///<summary>请移动标签，更新对应坐标，并选择字体尺寸和输入宽度限制后点击<Update>更新数据。</summary>
 				  public static string ModalView_TipsBody{
 				  get { return LangUtilities.GetString( "ModalView_TipsBody"); }} 

				 ///<summary>更新标签</summary>
 				  public static string ModalView_TipsTitle{
 				  get { return LangUtilities.GetString( "ModalView_TipsTitle"); }} 

				 ///<summary>菜单创建</summary>
 				  public static string ModalView_Title{
 				  get { return LangUtilities.GetString( "ModalView_Title"); }} 

				 ///<summary>视频连接,例如优酷/youtube等等上存视频的连接url</summary>
 				  public static string ModalView_VideoUrl_title{
 				  get { return LangUtilities.GetString( "ModalView_VideoUrl_title"); }} 

				 ///<summary>订单列表</summary>
 				  public static string My_Index_OrderList{
 				  get { return LangUtilities.GetString( "My_Index_OrderList"); }} 

				 ///<summary>给自己改个好听的昵称吧~~</summary>
 				  public static string My_Index_SwitchToNickName{
 				  get { return LangUtilities.GetString( "My_Index_SwitchToNickName"); }} 

				 ///<summary>请输入{0}</summary>
 				  public static string myRequiredAttributeAdapter_GetClientValidationRules_Input{
 				  get { return LangUtilities.GetString( "myRequiredAttributeAdapter_GetClientValidationRules_Input"); }} 

				 ///<summary>调整金额</summary>
 				  public static string Order_AdjustFee{
 				  get { return LangUtilities.GetString( "Order_AdjustFee"); }} 

				 ///<summary>活动ID</summary>
 				  public static string Order_CampaignID{
 				  get { return LangUtilities.GetString( "Order_CampaignID"); }} 

				 ///<summary>活动名称</summary>
 				  public static string Order_CampaignName{
 				  get { return LangUtilities.GetString( "Order_CampaignName"); }} 

				 ///<summary>优惠劵ID</summary>
 				  public static string Order_CouponID{
 				  get { return LangUtilities.GetString( "Order_CouponID"); }} 

				 ///<summary>订单日期</summary>
 				  public static string Order_CreatedDate{
 				  get { return LangUtilities.GetString( "Order_CreatedDate"); }} 

				 ///<summary>优惠金额</summary>
 				  public static string Order_DiscountFee{
 				  get { return LangUtilities.GetString( "Order_DiscountFee"); }} 

				 ///<summary>优惠劵面值</summary>
 				  public static string Order_FaceValue{
 				  get { return LangUtilities.GetString( "Order_FaceValue"); }} 

				 ///<summary>去支付</summary>
 				  public static string Order_Index_DefinitedUI_OkAndGotoPay{
 				  get { return LangUtilities.GetString( "Order_Index_DefinitedUI_OkAndGotoPay"); }} 

				 ///<summary>收货地址成功录入</summary>
 				  public static string Order_Index_ReturnMessage{
 				  get { return LangUtilities.GetString( "Order_Index_ReturnMessage"); }} 

				 ///<summary>订单ID</summary>
 				  public static string Order_OrderId{
 				  get { return LangUtilities.GetString( "Order_OrderId"); }} 

				 ///<summary>支付网关</summary>
 				  public static string Order_PayGateName{
 				  get { return LangUtilities.GetString( "Order_PayGateName"); }} 

				 ///<summary>付款金额</summary>
 				  public static string Order_Payment{
 				  get { return LangUtilities.GetString( "Order_Payment"); }} 

				 ///<summary>支付流水号</summary>
 				  public static string Order_PaymentNo{
 				  get { return LangUtilities.GetString( "Order_PaymentNo"); }} 

				 ///<summary>推薦者</summary>
 				  public static string Order_RecommUserId{
 				  get { return LangUtilities.GetString( "Order_RecommUserId"); }} 

				 ///<summary>订单ID错误,录入收货信息不成功</summary>
 				  public static string Order_Return_Wrong_OrderId{
 				  get { return LangUtilities.GetString( "Order_Return_Wrong_OrderId"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string Order_ShopID{
 				  get { return LangUtilities.GetString( "Order_ShopID"); }} 

				 ///<summary>订单状态</summary>
 				  public static string Order_StatusId{
 				  get { return LangUtilities.GetString( "Order_StatusId"); }} 

				 ///<summary>订单佣金</summary>
 				  public static string Order_TotalCommision{
 				  get { return LangUtilities.GetString( "Order_TotalCommision"); }} 

				 ///<summary>价格合计</summary>
 				  public static string Order_TotalRetailPrice{
 				  get { return LangUtilities.GetString( "Order_TotalRetailPrice"); }} 

				 ///<summary>用户ID</summary>
 				  public static string Order_UserId{
 				  get { return LangUtilities.GetString( "Order_UserId"); }} 

				 ///<summary>用户名</summary>
 				  public static string Order_UserName{
 				  get { return LangUtilities.GetString( "Order_UserName"); }} 

				 ///<summary>详细地址</summary>
 				  public static string OrderDetailView_Address{
 				  get { return LangUtilities.GetString( "OrderDetailView_Address"); }} 

				 ///<summary>所在县区</summary>
 				  public static string OrderDetailView_District{
 				  get { return LangUtilities.GetString( "OrderDetailView_District"); }} 

				 ///<summary>支付金额</summary>
 				  public static string OrderDetailView_Payment{
 				  get { return LangUtilities.GetString( "OrderDetailView_Payment"); }} 

				 ///<summary>手机号码</summary>
 				  public static string OrderDetailView_PhoneNumber{
 				  get { return LangUtilities.GetString( "OrderDetailView_PhoneNumber"); }} 

				 ///<summary>收件人</summary>
 				  public static string OrderDetailView_Recipient{
 				  get { return LangUtilities.GetString( "OrderDetailView_Recipient"); }} 

				 ///<summary>所在国家</summary>
 				  public static string OrderDetailView_State{
 				  get { return LangUtilities.GetString( "OrderDetailView_State"); }} 

				 ///<summary>佣金</summary>
 				  public static string OrderItem_Commision{
 				  get { return LangUtilities.GetString( "OrderItem_Commision"); }} 

				 ///<summary>佣金率</summary>
 				  public static string OrderItem_CommisionRate{
 				  get { return LangUtilities.GetString( "OrderItem_CommisionRate"); }} 

				 ///<summary>创建日期</summary>
 				  public static string OrderItem_CreatedDate{
 				  get { return LangUtilities.GetString( "OrderItem_CreatedDate"); }} 

				 ///<summary>金额</summary>
 				  public static string OrderItem_ItemAmount{
 				  get { return LangUtilities.GetString( "OrderItem_ItemAmount"); }} 

				 ///<summary>产品名称</summary>
 				  public static string OrderItem_ProductName{
 				  get { return LangUtilities.GetString( "OrderItem_ProductName"); }} 

				 ///<summary>属性描述</summary>
 				  public static string OrderItem_PropertyDesc{
 				  get { return LangUtilities.GetString( "OrderItem_PropertyDesc"); }} 

				 ///<summary>属性名称1</summary>
 				  public static string OrderItem_PropName1{
 				  get { return LangUtilities.GetString( "OrderItem_PropName1"); }} 

				 ///<summary>属性名称2</summary>
 				  public static string OrderItem_PropName2{
 				  get { return LangUtilities.GetString( "OrderItem_PropName2"); }} 

				 ///<summary>属性值1</summary>
 				  public static string OrderItem_PropValue1{
 				  get { return LangUtilities.GetString( "OrderItem_PropValue1"); }} 

				 ///<summary>属性值2</summary>
 				  public static string OrderItem_PropValue2{
 				  get { return LangUtilities.GetString( "OrderItem_PropValue2"); }} 

				 ///<summary>数量</summary>
 				  public static string OrderItem_Quantity{
 				  get { return LangUtilities.GetString( "OrderItem_Quantity"); }} 

				 ///<summary>零售价</summary>
 				  public static string OrderItem_RetailPrice{
 				  get { return LangUtilities.GetString( "OrderItem_RetailPrice"); }} 

				 ///<summary>Sku规格图</summary>
 				  public static string OrderItem_SkuImageUrl{
 				  get { return LangUtilities.GetString( "OrderItem_SkuImageUrl"); }} 

				 ///<summary>成交价</summary>
 				  public static string OrderItem_TradePrice{
 				  get { return LangUtilities.GetString( "OrderItem_TradePrice"); }} 

				 ///<summary>订单管理</summary>
 				  public static string OrderView_SubTitle{
 				  get { return LangUtilities.GetString( "OrderView_SubTitle"); }} 

				 ///<summary>订单列表</summary>
 				  public static string OrderView_Title{
 				  get { return LangUtilities.GetString( "OrderView_Title"); }} 

				 ///<summary>显示</summary>
 				  public static string Prodcate_IsLock{
 				  get { return LangUtilities.GetString( "Prodcate_IsLock"); }} 

				 ///<summary>类目层级</summary>
 				  public static string Prodcate_Levels{
 				  get { return LangUtilities.GetString( "Prodcate_Levels"); }} 

				 ///<summary>父类ID</summary>
 				  public static string Prodcate_ParentsProdCateID{
 				  get { return LangUtilities.GetString( "Prodcate_ParentsProdCateID"); }} 

				 ///<summary>类目ID</summary>
 				  public static string Prodcate_ProdCateID{
 				  get { return LangUtilities.GetString( "Prodcate_ProdCateID"); }} 

				 ///<summary>类目名称</summary>
 				  public static string Prodcate_ProdCateName{
 				  get { return LangUtilities.GetString( "Prodcate_ProdCateName"); }} 

				 ///<summary>新增类目成功</summary>
 				  public static string ProdCateV2_Index__NewProcateOK{
 				  get { return LangUtilities.GetString( "ProdCateV2_Index__NewProcateOK"); }} 

				 ///<summary>是否为交易属性</summary>
 				  public static string ProdPropertiesName_IsForTrading{
 				  get { return LangUtilities.GetString( "ProdPropertiesName_IsForTrading"); }} 

				 ///<summary>类目ID</summary>
 				  public static string ProdPropertiesName_ProdCateID{
 				  get { return LangUtilities.GetString( "ProdPropertiesName_ProdCateID"); }} 

				 ///<summary>类目名称</summary>
 				  public static string ProdPropertiesName_ProdCateName{
 				  get { return LangUtilities.GetString( "ProdPropertiesName_ProdCateName"); }} 

				 ///<summary>属性名称</summary>
 				  public static string ProdPropertiesName_PropertiesName{
 				  get { return LangUtilities.GetString( "ProdPropertiesName_PropertiesName"); }} 

				 ///<summary>展示图片</summary>
 				  public static string ProdPropertiesName_ShowPicture{
 				  get { return LangUtilities.GetString( "ProdPropertiesName_ShowPicture"); }} 

				 ///<summary>操作时间</summary>
 				  public static string ProdPropertiesValue_OperatedDate{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string ProdPropertiesValue_OperatedUserName{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_OperatedUserName"); }} 

				 ///<summary>类目ID</summary>
 				  public static string ProdPropertiesValue_ProdCateID{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_ProdCateID"); }} 

				 ///<summary>类目名称</summary>
 				  public static string ProdPropertiesValue_ProdCateName{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_ProdCateName"); }} 

				 ///<summary>属性名称</summary>
 				  public static string ProdPropertiesValue_PropertiesName{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_PropertiesName"); }} 

				 ///<summary>属性ID</summary>
 				  public static string ProdPropertiesValue_PropertiesNameID{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_PropertiesNameID"); }} 

				 ///<summary>属性值ID</summary>
 				  public static string ProdPropertiesValue_PropertiesValueID2{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_PropertiesValueID2"); }} 

				 ///<summary>属性值</summary>
 				  public static string ProdPropertiesValue_PropertiesValueName{
 				  get { return LangUtilities.GetString( "ProdPropertiesValue_PropertiesValueName"); }} 

				 ///<summary>Add new product ok</summary>
 				  public static string product_Addproduct_returnOK{
 				  get { return LangUtilities.GetString( "product_Addproduct_returnOK"); }} 

				 ///<summary>店内分类ID</summary>
 				  public static string Product_CategoryIDs{
 				  get { return LangUtilities.GetString( "Product_CategoryIDs"); }} 

				 ///<summary>佣金率</summary>
 				  public static string Product_CommisionRate{
 				  get { return LangUtilities.GetString( "Product_CommisionRate"); }} 

				 ///<summary>创建日期</summary>
 				  public static string Product_CreatedDate{
 				  get { return LangUtilities.GetString( "Product_CreatedDate"); }} 

				 ///<summary>操作日期</summary>
 				  public static string Product_OperatedDate{
 				  get { return LangUtilities.GetString( "Product_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string Product_OperatedUserName{
 				  get { return LangUtilities.GetString( "Product_OperatedUserName"); }} 

				 ///<summary>类目ID</summary>
 				  public static string Product_ProdCateID{
 				  get { return LangUtilities.GetString( "Product_ProdCateID"); }} 

				 ///<summary>商品描述</summary>
 				  public static string Product_ProdDesc{
 				  get { return LangUtilities.GetString( "Product_ProdDesc"); }} 

				 ///<summary>返回产品发布列表</summary>
 				  public static string Product_ProductAddUpd_ReturnToProductList{
 				  get { return LangUtilities.GetString( "Product_ProductAddUpd_ReturnToProductList"); }} 

				 ///<summary>商品ID</summary>
 				  public static string Product_ProductID{
 				  get { return LangUtilities.GetString( "Product_ProductID"); }} 

				 ///<summary>商品主图</summary>
 				  public static string Product_ProductImg{
 				  get { return LangUtilities.GetString( "Product_ProductImg"); }} 

				 ///<summary>商品名称</summary>
 				  public static string Product_ProductName{
 				  get { return LangUtilities.GetString( "Product_ProductName"); }} 

				 ///<summary>零售价格</summary>
 				  public static string Product_RetailPrice{
 				  get { return LangUtilities.GetString( "Product_RetailPrice"); }} 

				 ///<summary>销售状态</summary>
 				  public static string Product_SaleStatusID{
 				  get { return LangUtilities.GetString( "Product_SaleStatusID"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string Product_ShopID{
 				  get { return LangUtilities.GetString( "Product_ShopID"); }} 

				 ///<summary>推荐者展示</summary>
 				  public static string Product_StaffID{
 				  get { return LangUtilities.GetString( "Product_StaffID"); }} 

				 ///<summary>货号</summary>
 				  public static string Product_StyleNo{
 				  get { return LangUtilities.GetString( "Product_StyleNo"); }} 

				 ///<summary>供应商ID</summary>
 				  public static string Product_SupplierID{
 				  get { return LangUtilities.GetString( "Product_SupplierID"); }} 

				 ///<summary>商品标题</summary>
 				  public static string Product_Title{
 				  get { return LangUtilities.GetString( "Product_Title"); }} 

				 ///<summary>成交价格</summary>
 				  public static string Product_TradePrice{
 				  get { return LangUtilities.GetString( "Product_TradePrice"); }} 

				 ///<summary>视频连接</summary>
 				  public static string Product_VideoUrl{
 				  get { return LangUtilities.GetString( "Product_VideoUrl"); }} 

				 ///<summary>浏览IP数</summary>
 				  public static string Product_ViewsIP{
 				  get { return LangUtilities.GetString( "Product_ViewsIP"); }} 

				 ///<summary>产品名称用于交易显示，避免产生交易歧义</summary>
 				  public static string ProductAddUpd_Name_PlaceHolder{
 				  get { return LangUtilities.GetString( "ProductAddUpd_Name_PlaceHolder"); }} 

				 ///<summary>产品发布系统</summary>
 				  public static string ProductAddUpd_SubTitle{
 				  get { return LangUtilities.GetString( "ProductAddUpd_SubTitle"); }} 

				 ///<summary>新增产品</summary>
 				  public static string ProductAddUpd_Title{
 				  get { return LangUtilities.GetString( "ProductAddUpd_Title"); }} 

				 ///<summary>更新产品</summary>
 				  public static string ProductAddUpd_Title2{
 				  get { return LangUtilities.GetString( "ProductAddUpd_Title2"); }} 

				 ///<summary>店内分类ID</summary>
 				  public static string ProductCategory_CategoryID{
 				  get { return LangUtilities.GetString( "ProductCategory_CategoryID"); }} 

				 ///<summary>商品ID</summary>
 				  public static string ProductCategory_ProductID{
 				  get { return LangUtilities.GetString( "ProductCategory_ProductID"); }} 

				 ///<summary>默认root分类</summary>
 				  public static string ProductMgr_ActionMethod_ProductAddUpdate_DefautRoot{
 				  get { return LangUtilities.GetString( "ProductMgr_ActionMethod_ProductAddUpdate_DefautRoot"); }} 

				 ///<summary>商品类目</summary>
 				  public static string ProductPropertiesValue_Index_SubTitle{
 				  get { return LangUtilities.GetString( "ProductPropertiesValue_Index_SubTitle"); }} 

				 ///<summary>属性值管理</summary>
 				  public static string ProductPropertiesValue_Index_Title{
 				  get { return LangUtilities.GetString( "ProductPropertiesValue_Index_Title"); }} 

				 ///<summary>创建日期</summary>
 				  public static string ProductSku_CreatedDate{
 				  get { return LangUtilities.GetString( "ProductSku_CreatedDate"); }} 

				 ///<summary>操作日期</summary>
 				  public static string ProductSku_OperatedDate{
 				  get { return LangUtilities.GetString( "ProductSku_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string ProductSku_OperatedUserName{
 				  get { return LangUtilities.GetString( "ProductSku_OperatedUserName"); }} 

				 ///<summary>产品名称</summary>
 				  public static string ProductSku_ProductName{
 				  get { return LangUtilities.GetString( "ProductSku_ProductName"); }} 

				 ///<summary>Sku Id</summary>
 				  public static string ProductSku_ProductSkuId{
 				  get { return LangUtilities.GetString( "ProductSku_ProductSkuId"); }} 

				 ///<summary>属性描述</summary>
 				  public static string ProductSku_PropertyDesc{
 				  get { return LangUtilities.GetString( "ProductSku_PropertyDesc"); }} 

				 ///<summary>属性名称1</summary>
 				  public static string ProductSku_PropName1{
 				  get { return LangUtilities.GetString( "ProductSku_PropName1"); }} 

				 ///<summary>属性名称2</summary>
 				  public static string ProductSku_PropName2{
 				  get { return LangUtilities.GetString( "ProductSku_PropName2"); }} 

				 ///<summary>属性值1</summary>
 				  public static string ProductSku_PropValue1{
 				  get { return LangUtilities.GetString( "ProductSku_PropValue1"); }} 

				 ///<summary>属性值2</summary>
 				  public static string ProductSku_PropValue2{
 				  get { return LangUtilities.GetString( "ProductSku_PropValue2"); }} 

				 ///<summary>属性值集合</summary>
 				  public static string ProductSku_PropValueIDs{
 				  get { return LangUtilities.GetString( "ProductSku_PropValueIDs"); }} 

				 ///<summary>库存数量</summary>
 				  public static string ProductSku_Quantity{
 				  get { return LangUtilities.GetString( "ProductSku_Quantity"); }} 

				 ///<summary>SKU图</summary>
 				  public static string ProductSku_SkuImage{
 				  get { return LangUtilities.GetString( "ProductSku_SkuImage"); }} 

				 ///<summary>货号</summary>
 				  public static string ProductSku_StyleNo{
 				  get { return LangUtilities.GetString( "ProductSku_StyleNo"); }} 

				 ///<summary>产品规格库存</summary>
 				  public static string ProductSku_SubTitle{
 				  get { return LangUtilities.GetString( "ProductSku_SubTitle"); }} 

				 ///<summary>规格设置</summary>
 				  public static string ProductSku_Title{
 				  get { return LangUtilities.GetString( "ProductSku_Title"); }} 

				 ///<summary>成交价</summary>
 				  public static string ProductSku_TradePrice{
 				  get { return LangUtilities.GetString( "ProductSku_TradePrice"); }} 

				 ///<summary>产品SKU</summary>
 				  public static string ProductSkuList_SubTitle{
 				  get { return LangUtilities.GetString( "ProductSkuList_SubTitle"); }} 

				 ///<summary>Sku明细列表</summary>
 				  public static string ProductSkuList_Title{
 				  get { return LangUtilities.GetString( "ProductSkuList_Title"); }} 

				 ///<summary>产品管理</summary>
 				  public static string ProductView_SubTitle{
 				  get { return LangUtilities.GetString( "ProductView_SubTitle"); }} 

				 ///<summary>产品列表</summary>
 				  public static string ProductView_Title{
 				  get { return LangUtilities.GetString( "ProductView_Title"); }} 

				 ///<summary>操作日期</summary>
 				  public static string QuantFactor_DateTime{
 				  get { return LangUtilities.GetString( "QuantFactor_DateTime"); }} 

				 ///<summary>因素名称</summary>
 				  public static string QuantFactor_FactorName{
 				  get { return LangUtilities.GetString( "QuantFactor_FactorName"); }} 

				 ///<summary>操作用户</summary>
 				  public static string QuantFactor_OperatedUserName{
 				  get { return LangUtilities.GetString( "QuantFactor_OperatedUserName"); }} 

				 ///<summary>父类ID</summary>
 				  public static string QuantFactor_ParentsID{
 				  get { return LangUtilities.GetString( "QuantFactor_ParentsID"); }} 

				 ///<summary>量化因素ID</summary>
 				  public static string QuantFactor_QuantFactorID{
 				  get { return LangUtilities.GetString( "QuantFactor_QuantFactorID"); }} 

				 ///<summary>量化因素ID</summary>
 				  public static string QuantFactor_QuantizationFactorID{
 				  get { return LangUtilities.GetString( "QuantFactor_QuantizationFactorID"); }} 

				 ///<summary>因素分值</summary>
 				  public static string QuantFactor_Score{
 				  get { return LangUtilities.GetString( "QuantFactor_Score"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string QuantFactor_ShopID{
 				  get { return LangUtilities.GetString( "QuantFactor_ShopID"); }} 

				 ///<summary>Top50排序</summary>
 				  public static string QuantFactor_Top50{
 				  get { return LangUtilities.GetString( "QuantFactor_Top50"); }} 

				 ///<summary>根因子</summary>
 				  public static string QuantFator_RootFactors{
 				  get { return LangUtilities.GetString( "QuantFator_RootFactors"); }} 

				 ///<summary>管理店铺量化因子(因素)</summary>
 				  public static string QuantFator_SubTitle{
 				  get { return LangUtilities.GetString( "QuantFator_SubTitle"); }} 

				 ///<summary>量化因素</summary>
 				  public static string QuantList_QuantFator{
 				  get { return LangUtilities.GetString( "QuantList_QuantFator"); }} 

				 ///<summary>量化因素列表</summary>
 				  public static string QuantList_Title{
 				  get { return LangUtilities.GetString( "QuantList_Title"); }} 

				 ///<summary>区域</summary>
 				  public static string RenderPhoneNumber_AreaCode{
 				  get { return LangUtilities.GetString( "RenderPhoneNumber_AreaCode"); }} 

				 ///<summary>生成数量</summary>
 				  public static string RenderPhoneNumber_RenderAmount{
 				  get { return LangUtilities.GetString( "RenderPhoneNumber_RenderAmount"); }} 

				 ///<summary>生成结果</summary>
 				  public static string RenderPhoneNumber_RenderResult{
 				  get { return LangUtilities.GetString( "RenderPhoneNumber_RenderResult"); }} 

				 ///<summary>销售状态描述</summary>
 				  public static string SaleStatus_SaleStatusDesc{
 				  get { return LangUtilities.GetString( "SaleStatus_SaleStatusDesc"); }} 

				 ///<summary>销售状态描述最少3位，最大20字</summary>
 				  public static string SaleStatus_SaleStatusDesc_ErrorMessage{
 				  get { return LangUtilities.GetString( "SaleStatus_SaleStatusDesc_ErrorMessage"); }} 

				 ///<summary>销售状态ID</summary>
 				  public static string SaleStatus_SaleStatusID{
 				  get { return LangUtilities.GetString( "SaleStatus_SaleStatusID"); }} 

				 ///<summary>启用本机认证密码</summary>
 				  public static string SendMailInfo_EnablePasswordAuthentication{
 				  get { return LangUtilities.GetString( "SendMailInfo_EnablePasswordAuthentication"); }} 

				 ///<summary>启动SSL</summary>
 				  public static string SendMailInfo_EnableSSL{
 				  get { return LangUtilities.GetString( "SendMailInfo_EnableSSL"); }} 

				 ///<summary>启动TSL</summary>
 				  public static string SendMailInfo_EnableTSL{
 				  get { return LangUtilities.GetString( "SendMailInfo_EnableTSL"); }} 

				 ///<summary>发送EMIAL</summary>
 				  public static string SendMailInfo_FromMailAddress{
 				  get { return LangUtilities.GetString( "SendMailInfo_FromMailAddress"); }} 

				 ///<summary>邮件账号平台</summary>
 				  public static string SendMailInfo_SenderOfCompany{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderOfCompany"); }} 

				 ///<summary>SMTP 126</summary>
 				  public static string SendMailInfo_SenderOfCompany_126{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderOfCompany_126"); }} 

				 ///<summary>163</summary>
 				  public static string SendMailInfo_SenderOfCompany_163{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderOfCompany_163"); }} 

				 ///<summary>GOOGLE</summary>
 				  public static string SendMailInfo_SenderOfCompany_GOOGLE{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderOfCompany_GOOGLE"); }} 

				 ///<summary>QQ</summary>
 				  public static string SendMailInfo_SenderOfCompany_QQ{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderOfCompany_QQ"); }} 

				 ///<summary>邮件服务器</summary>
 				  public static string SendMailInfo_SenderServerHost{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderServerHost"); }} 

				 ///<summary>邮件服务器端口</summary>
 				  public static string SendMailInfo_SenderServerHostPort{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderServerHostPort"); }} 

				 ///<summary>发送账号</summary>
 				  public static string SendMailInfo_SenderUserName{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderUserName"); }} 

				 ///<summary>发送账号就是EMAIL地址，或可能是abc@xx.com的@前面部分。</summary>
 				  public static string SendMailInfo_SenderUserName_TIPs{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderUserName_TIPs"); }} 

				 ///<summary>密码或授权码</summary>
 				  public static string SendMailInfo_SenderUserPassword{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderUserPassword"); }} 

				 ///<summary>个别邮件发送账号不使用Email密码作为SMPT发送密码，而是授权码，例如126,163邮箱</summary>
 				  public static string SendMailInfo_SenderUserPassword_TIPs{
 				  get { return LangUtilities.GetString( "SendMailInfo_SenderUserPassword_TIPs"); }} 

				 ///<summary>发邮件账号设置</summary>
 				  public static string SendMailInfo_Title{
 				  get { return LangUtilities.GetString( "SendMailInfo_Title"); }} 

				 ///<summary>是否为富文本HTML5模板</summary>
 				  public static string SeoExtand_IsSeoHtmlContext{
 				  get { return LangUtilities.GetString( "SeoExtand_IsSeoHtmlContext"); }} 

				 ///<summary>操作日期</summary>
 				  public static string SeoExtand_OperatedDate{
 				  get { return LangUtilities.GetString( "SeoExtand_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string SeoExtand_OperatedUserName{
 				  get { return LangUtilities.GetString( "SeoExtand_OperatedUserName"); }} 

				 ///<summary>父关键词ID</summary>
 				  public static string SeoExtand_ParentsSeoExtandID{
 				  get { return LangUtilities.GetString( "SeoExtand_ParentsSeoExtandID"); }} 

				 ///<summary>父级关键词</summary>
 				  public static string SeoExtand_SeoExtandID{
 				  get { return LangUtilities.GetString( "SeoExtand_SeoExtandID"); }} 

				 ///<summary>Html格式内容</summary>
 				  public static string SeoExtand_SeoHtmlContext{
 				  get { return LangUtilities.GetString( "SeoExtand_SeoHtmlContext"); }} 

				 ///<summary>关键词/短语</summary>
 				  public static string SeoExtand_SeoKeyWord{
 				  get { return LangUtilities.GetString( "SeoExtand_SeoKeyWord"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string SeoExtand_ShopID{
 				  get { return LangUtilities.GetString( "SeoExtand_ShopID"); }} 

				 ///<summary>Top50排序</summary>
 				  public static string SeoExtand_Top50{
 				  get { return LangUtilities.GetString( "SeoExtand_Top50"); }} 

				 ///<summary>UserId</summary>
 				  public static string SeoExtand_UserId{
 				  get { return LangUtilities.GetString( "SeoExtand_UserId"); }} 

				 ///<summary>证书</summary>
 				  public static string Shop_cerPath{
 				  get { return LangUtilities.GetString( "Shop_cerPath"); }} 

				 ///<summary>货币标准</summary>
 				  public static string Shop_CurrencySymbol{
 				  get { return LangUtilities.GetString( "Shop_CurrencySymbol"); }} 

				 ///<summary>fb二维码</summary>
 				  public static string Shop_fbQRcode{
 				  get { return LangUtilities.GetString( "Shop_fbQRcode"); }} 

				 ///<summary>页脚模板</summary>
 				  public static string Shop_FooterTemplate{
 				  get { return LangUtilities.GetString( "Shop_FooterTemplate"); }} 

				 ///<summary>域名</summary>
 				  public static string Shop_HostName{
 				  get { return LangUtilities.GetString( "Shop_HostName"); }} 

				 ///<summary>资讯模式</summary>
 				  public static string Shop_IsInfoMode{
 				  get { return LangUtilities.GetString( "Shop_IsInfoMode"); }} 

				 ///<summary>操作日期</summary>
 				  public static string Shop_OperatedDate{
 				  get { return LangUtilities.GetString( "Shop_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string Shop_OperatedUserName{
 				  get { return LangUtilities.GetString( "Shop_OperatedUserName"); }} 

				 ///<summary>服务电话</summary>
 				  public static string Shop_PhoneNumber{
 				  get { return LangUtilities.GetString( "Shop_PhoneNumber"); }} 

				 ///<summary>展示货币</summary>
 				  public static string Shop_ShopCurrency{
 				  get { return LangUtilities.GetString( "Shop_ShopCurrency"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string Shop_ShopID{
 				  get { return LangUtilities.GetString( "Shop_ShopID"); }} 

				 ///<summary>店铺logo</summary>
 				  public static string Shop_ShopLogo{
 				  get { return LangUtilities.GetString( "Shop_ShopLogo"); }} 

				 ///<summary>店铺名称</summary>
 				  public static string Shop_ShopName{
 				  get { return LangUtilities.GetString( "Shop_ShopName"); }} 

				 ///<summary>头条二维码</summary>
 				  public static string Shop_ToutiaoQRcode{
 				  get { return LangUtilities.GetString( "Shop_ToutiaoQRcode"); }} 

				 ///<summary>店长</summary>
 				  public static string Shop_UserName{
 				  get { return LangUtilities.GetString( "Shop_UserName"); }} 

				 ///<summary>店铺视图</summary>
 				  public static string Shop_ViewTemplate{
 				  get { return LangUtilities.GetString( "Shop_ViewTemplate"); }} 

				 ///<summary>微博二维码</summary>
 				  public static string Shop_WeiboQRcode{
 				  get { return LangUtilities.GetString( "Shop_WeiboQRcode"); }} 

				 ///<summary>微信二维码</summary>
 				  public static string Shop_WeixinQRcode{
 				  get { return LangUtilities.GetString( "Shop_WeixinQRcode"); }} 

				 ///<summary>价格优惠标签</summary>
 				  public static string ShopCampCreate_PriceLabel{
 				  get { return LangUtilities.GetString( "ShopCampCreate_PriceLabel"); }} 

				 ///<summary>显示商品详情页的价格促销标签</summary>
 				  public static string ShopCampCreate_PriceLabelTips{
 				  get { return LangUtilities.GetString( "ShopCampCreate_PriceLabelTips"); }} 

				 ///<summary>活动时间</summary>
 				  public static string ShopCampCreate_PromoteTime{
 				  get { return LangUtilities.GetString( "ShopCampCreate_PromoteTime"); }} 

				 ///<summary>店铺优惠活动</summary>
 				  public static string ShopCampCreate_Subtitle{
 				  get { return LangUtilities.GetString( "ShopCampCreate_Subtitle"); }} 

				 ///<summary>活动商品数量</summary>
 				  public static string ShopCampList_PromoteProduct{
 				  get { return LangUtilities.GetString( "ShopCampList_PromoteProduct"); }} 

				 ///<summary>店铺优惠活动</summary>
 				  public static string ShopCampList_SubTitle{
 				  get { return LangUtilities.GetString( "ShopCampList_SubTitle"); }} 

				 ///<summary>店铺优惠活动列表</summary>
 				  public static string ShopCampList_Title{
 				  get { return LangUtilities.GetString( "ShopCampList_Title"); }} 

				 ///<summary>删除店铺分类及其子节点∷</summary>
 				  public static string ShopCategoryList_ShopCategory_btnDelete_Title{
 				  get { return LangUtilities.GetString( "ShopCategoryList_ShopCategory_btnDelete_Title"); }} 

				 ///<summary>店铺分类</summary>
 				  public static string ShopCategoryList_ShopCategory_Category1{
 				  get { return LangUtilities.GetString( "ShopCategoryList_ShopCategory_Category1"); }} 

				 ///<summary>管理</summary>
 				  public static string ShopCategoryList_ShopCategory_SubTitle{
 				  get { return LangUtilities.GetString( "ShopCategoryList_ShopCategory_SubTitle"); }} 

				 ///<summary>店铺分类</summary>
 				  public static string ShopCategoryList_ShopCategory_Title{
 				  get { return LangUtilities.GetString( "ShopCategoryList_ShopCategory_Title"); }} 

				 ///<summary>必须是店铺创建的用户才能操作店铺复制</summary>
 				  public static string ShopCopyNotAsShopOwnerResult{
 				  get { return LangUtilities.GetString( "ShopCopyNotAsShopOwnerResult"); }} 

				 ///<summary>店铺复制成功!!!</summary>
 				  public static string ShopCopyResultSuccess{
 				  get { return LangUtilities.GetString( "ShopCopyResultSuccess"); }} 

				 ///<summary>复制的来源店铺ID或店铺不存在!!!</summary>
 				  public static string ShopCopyShopNotExitResult{
 				  get { return LangUtilities.GetString( "ShopCopyShopNotExitResult"); }} 

				 ///<summary>目标店铺不存在,必须先创建目标店铺,并且必须是创建店铺人操作复制</summary>
 				  public static string ShopCopyTargetShopNotExitResult{
 				  get { return LangUtilities.GetString( "ShopCopyTargetShopNotExitResult"); }} 

				 ///<summary>店铺复制(ONLY INFODETAILS AND PRODUCTS)</summary>
 				  public static string ShopCopyTitle{
 				  get { return LangUtilities.GetString( "ShopCopyTitle"); }} 

				 ///<summary>页脚模板</summary>
 				  public static string ShopFooterTemplateViewModel_FooterTemplate{
 				  get { return LangUtilities.GetString( "ShopFooterTemplateViewModel_FooterTemplate"); }} 

				 ///<summary>店铺页脚模板</summary>
 				  public static string ShopFooterTemplateViewModel_UpShopFooterCS_Title{
 				  get { return LangUtilities.GetString( "ShopFooterTemplateViewModel_UpShopFooterCS_Title"); }} 

				 ///<summary>渠道类型</summary>
 				  public static string ShopStaff_ChannelID{
 				  get { return LangUtilities.GetString( "ShopStaff_ChannelID"); }} 

				 ///<summary>头衔</summary>
 				  public static string ShopStaff_ContactTitle{
 				  get { return LangUtilities.GetString( "ShopStaff_ContactTitle"); }} 

				 ///<summary>形象</summary>
 				  public static string ShopStaff_IconPortrait{
 				  get { return LangUtilities.GetString( "ShopStaff_IconPortrait"); }} 

				 ///<summary>简介</summary>
 				  public static string ShopStaff_Introduction{
 				  get { return LangUtilities.GetString( "ShopStaff_Introduction"); }} 

				 ///<summary>会员确认</summary>
 				  public static string ShopStaff_IsConfirmed{
 				  get { return LangUtilities.GetString( "ShopStaff_IsConfirmed"); }} 

				 ///<summary>操作日期</summary>
 				  public static string ShopStaff_OperatedDate{
 				  get { return LangUtilities.GetString( "ShopStaff_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string ShopStaff_OperatedUserName{
 				  get { return LangUtilities.GetString( "ShopStaff_OperatedUserName"); }} 

				 ///<summary>其它渠道名称</summary>
 				  public static string ShopStaff_OtherChannelName{
 				  get { return LangUtilities.GetString( "ShopStaff_OtherChannelName"); }} 

				 ///<summary>其他社区二维码</summary>
 				  public static string ShopStaff_OtherQrcode{
 				  get { return LangUtilities.GetString( "ShopStaff_OtherQrcode"); }} 

				 ///<summary>公众号</summary>
 				  public static string ShopStaff_PublicNo{
 				  get { return LangUtilities.GetString( "ShopStaff_PublicNo"); }} 

				 ///<summary>社区二维码</summary>
 				  public static string ShopStaff_Qrcode{
 				  get { return LangUtilities.GetString( "ShopStaff_Qrcode"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string ShopStaff_ShopID{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopID"); }} 

				 ///<summary>头衔</summary>
 				  public static string ShopStaff_ShopStaffAdd_ContactTitleTips{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_ContactTitleTips"); }} 

				 ///<summary>管理的公众号</summary>
 				  public static string ShopStaff_ShopStaffAdd_PublicNoTips{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_PublicNoTips"); }} 

				 ///<summary>返回团队列表</summary>
 				  public static string ShopStaff_ShopStaffAdd_ReturnStaffList{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_ReturnStaffList"); }} 

				 ///<summary>选择渠道</summary>
 				  public static string ShopStaff_ShopStaffAdd_Selectchannel{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_Selectchannel"); }} 

				 ///<summary>系统自动生成编号。</summary>
 				  public static string ShopStaff_ShopStaffAdd_ShopStaffIDTips{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_ShopStaffIDTips"); }} 

				 ///<summary>已注册的会员ID(UserId)</summary>
 				  public static string ShopStaff_ShopStaffAdd_ShopStaffUserId{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_ShopStaffUserId"); }} 

				 ///<summary>店铺设置管理</summary>
 				  public static string ShopStaff_ShopStaffAdd_SubTitle{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_SubTitle"); }} 

				 ///<summary>添加成员</summary>
 				  public static string ShopStaff_ShopStaffAdd_Title{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffAdd_Title"); }} 

				 ///<summary>员工编号</summary>
 				  public static string ShopStaff_ShopStaffID{
 				  get { return LangUtilities.GetString( "ShopStaff_ShopStaffID"); }} 

				 ///<summary>成员姓名/昵称</summary>
 				  public static string ShopStaff_StaffName{
 				  get { return LangUtilities.GetString( "ShopStaff_StaffName"); }} 

				 ///<summary>UserId</summary>
 				  public static string ShopStaff_UserId{
 				  get { return LangUtilities.GetString( "ShopStaff_UserId"); }} 

				 ///<summary>UserName</summary>
 				  public static string ShopStaff_UserName{
 				  get { return LangUtilities.GetString( "ShopStaff_UserName"); }} 

				 ///<summary>店铺角色(职位)管理</summary>
 				  public static string ShopStaffAdd_OpenShopStaffAddRole{
 				  get { return LangUtilities.GetString( "ShopStaffAdd_OpenShopStaffAddRole"); }} 

				 ///<summary>添加会员</summary>
 				  public static string ShopStaffAddRoleView_AddMember{
 				  get { return LangUtilities.GetString( "ShopStaffAddRoleView_AddMember"); }} 

				 ///<summary>员工添加角色:\n\n服务器端处理数据失败</summary>
 				  public static string ShopStaffAddRoleView_JS_returnActionResult_alert{
 				  get { return LangUtilities.GetString( "ShopStaffAddRoleView_JS_returnActionResult_alert"); }} 

				 ///<summary>添加渠道</summary>
 				  public static string ShopStaffList_Btn_AddChannel{
 				  get { return LangUtilities.GetString( "ShopStaffList_Btn_AddChannel"); }} 

				 ///<summary>渠 道 ID</summary>
 				  public static string ShopStaffList_ChannelID{
 				  get { return LangUtilities.GetString( "ShopStaffList_ChannelID"); }} 

				 ///<summary>1.请选择渠道\n\n2.上存二维码图片</summary>
 				  public static string ShopStaffList_JS_Savechanges_click{
 				  get { return LangUtilities.GetString( "ShopStaffList_JS_Savechanges_click"); }} 

				 ///<summary>成员渠道列表</summary>
 				  public static string ShopStaffList_StaffChannelList{
 				  get { return LangUtilities.GetString( "ShopStaffList_StaffChannelList"); }} 

				 ///<summary>店铺团队管理</summary>
 				  public static string ShopStaffList_SubTitle{
 				  get { return LangUtilities.GetString( "ShopStaffList_SubTitle"); }} 

				 ///<summary>团队</summary>
 				  public static string ShopStaffList_Title{
 				  get { return LangUtilities.GetString( "ShopStaffList_Title"); }} 

				 ///<summary>You have {0} Visitors</summary>
 				  public static string SourceStatisticByRecomm_UserViews{
 				  get { return LangUtilities.GetString( "SourceStatisticByRecomm_UserViews"); }} 

				 ///<summary>创建日期</summary>
 				  public static string SourceStatistics_CreatedDate{
 				  get { return LangUtilities.GetString( "SourceStatistics_CreatedDate"); }} 

				 ///<summary>持续时间(m)</summary>
 				  public static string SourceStatistics_Duration{
 				  get { return LangUtilities.GetString( "SourceStatistics_Duration"); }} 

				 ///<summary>更新日期</summary>
 				  public static string SourceStatistics_LastUpdateDate{
 				  get { return LangUtilities.GetString( "SourceStatistics_LastUpdateDate"); }} 

				 ///<summary>页面加载(ms)</summary>
 				  public static string SourceStatistics_loadTime{
 				  get { return LangUtilities.GetString( "SourceStatistics_loadTime"); }} 

				 ///<summary>OpenID</summary>
 				  public static string SourceStatistics_OpenID{
 				  get { return LangUtilities.GetString( "SourceStatistics_OpenID"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string SourceStatistics_ShopID{
 				  get { return LangUtilities.GetString( "SourceStatistics_ShopID"); }} 

				 ///<summary>来源地区</summary>
 				  public static string SourceStatistics_SourceArea{
 				  get { return LangUtilities.GetString( "SourceStatistics_SourceArea"); }} 

				 ///<summary>来源Url</summary>
 				  public static string SourceStatistics_SourceUrl{
 				  get { return LangUtilities.GetString( "SourceStatistics_SourceUrl"); }} 

				 ///<summary>IsValid</summary>
 				  public static string SourceStatistics_Status{
 				  get { return LangUtilities.GetString( "SourceStatistics_Status"); }} 

				 ///<summary>标题</summary>
 				  public static string SourceStatistics_Title{
 				  get { return LangUtilities.GetString( "SourceStatistics_Title"); }} 

				 ///<summary>UserId</summary>
 				  public static string SourceStatistics_UserId{
 				  get { return LangUtilities.GetString( "SourceStatistics_UserId"); }} 

				 ///<summary>WxNickName</summary>
 				  public static string SourceStatistics_WxNickName{
 				  get { return LangUtilities.GetString( "SourceStatistics_WxNickName"); }} 

				 ///<summary>公司地址</summary>
 				  public static string Supplier_CompanyAddress{
 				  get { return LangUtilities.GetString( "Supplier_CompanyAddress"); }} 

				 ///<summary>公司名称</summary>
 				  public static string Supplier_CompanyName{
 				  get { return LangUtilities.GetString( "Supplier_CompanyName"); }} 

				 ///<summary>联系人</summary>
 				  public static string Supplier_ContactName{
 				  get { return LangUtilities.GetString( "Supplier_ContactName"); }} 

				 ///<summary>供应商匿名</summary>
 				  public static string Supplier_ContactNick{
 				  get { return LangUtilities.GetString( "Supplier_ContactNick"); }} 

				 ///<summary>操作日期</summary>
 				  public static string Supplier_OperatedDate{
 				  get { return LangUtilities.GetString( "Supplier_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string Supplier_OperatedUserName{
 				  get { return LangUtilities.GetString( "Supplier_OperatedUserName"); }} 

				 ///<summary>联系人手机</summary>
 				  public static string Supplier_PhoneNumber{
 				  get { return LangUtilities.GetString( "Supplier_PhoneNumber"); }} 

				 ///<summary>备注</summary>
 				  public static string Supplier_Remarks{
 				  get { return LangUtilities.GetString( "Supplier_Remarks"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string Supplier_ShopID{
 				  get { return LangUtilities.GetString( "Supplier_ShopID"); }} 

				 ///<summary>供应商ID</summary>
 				  public static string Supplier_SupplierID{
 				  get { return LangUtilities.GetString( "Supplier_SupplierID"); }} 

				 ///<summary>X 坐标</summary>
 				  public static string TemplateNotePosition_X{
 				  get { return LangUtilities.GetString( "TemplateNotePosition_X"); }} 

				 ///<summary>Y 坐标</summary>
 				  public static string TemplateNotePosition_Y{
 				  get { return LangUtilities.GetString( "TemplateNotePosition_Y"); }} 

				 ///<summary>模板定义</summary>
 				  public static string TemplateNotePositionView_SubTitle{
 				  get { return LangUtilities.GetString( "TemplateNotePositionView_SubTitle"); }} 

				 ///<summary>模板管理</summary>
 				  public static string TemplateNotePositionView_Title{
 				  get { return LangUtilities.GetString( "TemplateNotePositionView_Title"); }} 

				 ///<summary>店铺视图上存</summary>
 				  public static string UpShopViewTemplate_Title{
 				  get { return LangUtilities.GetString( "UpShopViewTemplate_Title"); }} 

				 ///<summary>无可分配的资源</summary>
 				  public static string User_AsignToAccountMgrID_Msg_NoAssigned{
 				  get { return LangUtilities.GetString( "User_AsignToAccountMgrID_Msg_NoAssigned"); }} 

				 ///<summary><div>请选择分发推广渠道帐号ID (或可能({0})不存在)</div> <br></summary>
 				  public static string User_AsignToAccountMgrID_Msg2{
 				  get { return LangUtilities.GetString( "User_AsignToAccountMgrID_Msg2"); }} 

				 ///<summary><div>请选择分发(推广渠道帐号ID) 与 分发(客户来源)</div></summary>
 				  public static string User_AsignToAccountMgrID_Msg3{
 				  get { return LangUtilities.GetString( "User_AsignToAccountMgrID_Msg3"); }} 

				 ///<summary>拉 黑</summary>
 				  public static string User_DistributeToAccountMgrID_Block{
 				  get { return LangUtilities.GetString( "User_DistributeToAccountMgrID_Block"); }} 

				 ///<summary>请先选择渠道推广帐号和分发来源</summary>
 				  public static string User_DistributeToAccountMgrID_Clk_message{
 				  get { return LangUtilities.GetString( "User_DistributeToAccountMgrID_Clk_message"); }} 

				 ///<summary>随 机</summary>
 				  public static string User_DistributeToAccountMgrID_Random{
 				  get { return LangUtilities.GetString( "User_DistributeToAccountMgrID_Random"); }} 

				 ///<summary>分 发</summary>
 				  public static string User_DistributeToAccountMgrID_Value{
 				  get { return LangUtilities.GetString( "User_DistributeToAccountMgrID_Value"); }} 

				 ///<summary>UserId、Email、手机、昵称、City等</summary>
 				  public static string User_Inder_SearchString_Title{
 				  get { return LangUtilities.GetString( "User_Inder_SearchString_Title"); }} 

				 ///<summary>独占:一个渠道帐号ID独占当前资源(true)</summary>
 				  public static string User_IsMonopoly_Tilte{
 				  get { return LangUtilities.GetString( "User_IsMonopoly_Tilte"); }} 

				 ///<summary><h1>抱歉 没有相关权限(业务推广-BusinessPromotion)</h1></summary>
 				  public static string User_LoadAccountDownLog_Message1{
 				  get { return LangUtilities.GetString( "User_LoadAccountDownLog_Message1"); }} 

				 ///<summary><h1>没有分配使用</h1><p class="lead">当前用户还没有分配到当前帐号使用权</p></summary>
 				  public static string User_LoadAccountDownLog_Message2{
 				  get { return LangUtilities.GetString( "User_LoadAccountDownLog_Message2"); }} 

				 ///<summary>没有 AccountID</summary>
 				  public static string User_LoadAccountDownLog_NoAccountID{
 				  get { return LangUtilities.GetString( "User_LoadAccountDownLog_NoAccountID"); }} 

				 ///<summary>帐户ID 没有分配任何资源数据</summary>
 				  public static string User_LoadAccountDownLog_NotAssignedAnyResourceData{
 				  get { return LangUtilities.GetString( "User_LoadAccountDownLog_NotAssignedAnyResourceData"); }} 

				 ///<summary>抱歉,没有相关查询结果</summary>
 				  public static string User_LoadAccountMgrDropDownData_Msgtext{
 				  get { return LangUtilities.GetString( "User_LoadAccountMgrDropDownData_Msgtext"); }} 

				 ///<summary>及其节点成功删除</summary>
 				  public static string User_QuantFactorDelete_msg{
 				  get { return LangUtilities.GetString( "User_QuantFactorDelete_msg"); }} 

				 ///<summary>程序出错,操作失败</summary>
 				  public static string User_QuantFactorDelete_msgError{
 				  get { return LangUtilities.GetString( "User_QuantFactorDelete_msgError"); }} 

				 ///<summary>详细地址</summary>
 				  public static string UserAddress_Address{
 				  get { return LangUtilities.GetString( "UserAddress_Address"); }} 

				 ///<summary>所在国家</summary>
 				  public static string UserAddress_Country{
 				  get { return LangUtilities.GetString( "UserAddress_Country"); }} 

				 ///<summary>默认地址</summary>
 				  public static string UserAddress_IsDefault{
 				  get { return LangUtilities.GetString( "UserAddress_IsDefault"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserAddress_OperatedDate{
 				  get { return LangUtilities.GetString( "UserAddress_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string UserAddress_OperatedUserName{
 				  get { return LangUtilities.GetString( "UserAddress_OperatedUserName"); }} 

				 ///<summary>手机号码</summary>
 				  public static string UserAddress_PhoneNumber{
 				  get { return LangUtilities.GetString( "UserAddress_PhoneNumber"); }} 

				 ///<summary>邮政编号</summary>
 				  public static string UserAddress_PostCode{
 				  get { return LangUtilities.GetString( "UserAddress_PostCode"); }} 

				 ///<summary>ShopID</summary>
 				  public static string UserAddress_ShopID{
 				  get { return LangUtilities.GetString( "UserAddress_ShopID"); }} 

				 ///<summary>电话号码</summary>
 				  public static string UserAddress_TelePhoneNumber{
 				  get { return LangUtilities.GetString( "UserAddress_TelePhoneNumber"); }} 

				 ///<summary>渠道ID</summary>
 				  public static string UserChannel_ChangelID{
 				  get { return LangUtilities.GetString( "UserChannel_ChangelID"); }} 

				 ///<summary>渠道名称</summary>
 				  public static string UserChannel_ChannelName{
 				  get { return LangUtilities.GetString( "UserChannel_ChannelName"); }} 

				 ///<summary>渠道二维码</summary>
 				  public static string UserChannel_ChannelQRcode{
 				  get { return LangUtilities.GetString( "UserChannel_ChannelQRcode"); }} 

				 ///<summary>LoginID</summary>
 				  public static string UserChannel_LoginID{
 				  get { return LangUtilities.GetString( "UserChannel_LoginID"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserChannel_OperatedDate{
 				  get { return LangUtilities.GetString( "UserChannel_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string UserChannel_OperatedUserName{
 				  get { return LangUtilities.GetString( "UserChannel_OperatedUserName"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserChannel_ShopID{
 				  get { return LangUtilities.GetString( "UserChannel_ShopID"); }} 

				 ///<summary>用户渠道ID</summary>
 				  public static string UserChannel_UserChannelID{
 				  get { return LangUtilities.GetString( "UserChannel_UserChannelID"); }} 

				 ///<summary>UserId</summary>
 				  public static string UserChannel_UserId{
 				  get { return LangUtilities.GetString( "UserChannel_UserId"); }} 

				 ///<summary>已成功提交結算請求（金額為：{0}）<br/> 時間段：{1}-{2} （上述不包括已經提交的）｛3｝</summary>
 				  public static string UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg{
 				  get { return LangUtilities.GetString( "UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg"); }} 

				 ///<summary>金额为：{0} ，避免耗费财务工作量，每次计算要求20元起。</summary>
 				  public static string UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg1{
 				  get { return LangUtilities.GetString( "UserFinance_CalcUserFinanceCurrentMonth_ReturnMsg1"); }} 

				 ///<summary>最新提交结算请求（金额为：{0}）<br/> 时间段：{1}-{2} （上述不包括已经提交的）｛3｝</summary>
 				  public static string UserFinance_CalcUserFinanceCurrentMonth_ReturnMsgLastUpd{
 				  get { return LangUtilities.GetString( "UserFinance_CalcUserFinanceCurrentMonth_ReturnMsgLastUpd"); }} 

				 ///<summary>创建日期</summary>
 				  public static string UserFinance_CreatedDate{
 				  get { return LangUtilities.GetString( "UserFinance_CreatedDate"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserFinance_DateTime{
 				  get { return LangUtilities.GetString( "UserFinance_DateTime"); }} 

				 ///<summary>结束日期</summary>
 				  public static string UserFinance_EndDate{
 				  get { return LangUtilities.GetString( "UserFinance_EndDate"); }} 

				 ///<summary>上月提交结算的金额：｛0｝</summary>
 				  public static string UserFinance_My_Index_LastMonthTotalAmount_Msg{
 				  get { return LangUtilities.GetString( "UserFinance_My_Index_LastMonthTotalAmount_Msg"); }} 

				 ///<summary>已提交结算请求（总金额为：{0}）</summary>
 				  public static string UserFinance_My_Index_SubmittedMonthTotalAmount_Msg{
 				  get { return LangUtilities.GetString( "UserFinance_My_Index_SubmittedMonthTotalAmount_Msg"); }} 

				 ///<summary>ParentUserId</summary>
 				  public static string UserFinance_ParentUserId{
 				  get { return LangUtilities.GetString( "UserFinance_ParentUserId"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserFinance_ShopID{
 				  get { return LangUtilities.GetString( "UserFinance_ShopID"); }} 

				 ///<summary>起始日期</summary>
 				  public static string UserFinance_StartDate{
 				  get { return LangUtilities.GetString( "UserFinance_StartDate"); }} 

				 ///<summary>状态ID</summary>
 				  public static string UserFinance_StatusId{
 				  get { return LangUtilities.GetString( "UserFinance_StatusId"); }} 

				 ///<summary>总金额</summary>
 				  public static string UserFinance_TotalAmount{
 				  get { return LangUtilities.GetString( "UserFinance_TotalAmount"); }} 

				 ///<summary>ID</summary>
 				  public static string UserFinance_UserFinanceID{
 				  get { return LangUtilities.GetString( "UserFinance_UserFinanceID"); }} 

				 ///<summary>UserId</summary>
 				  public static string UserFinance_UserId{
 				  get { return LangUtilities.GetString( "UserFinance_UserId"); }} 

				 ///<summary>创建日期</summary>
 				  public static string UserFinanceItem_CreatedDate{
 				  get { return LangUtilities.GetString( "UserFinanceItem_CreatedDate"); }} 

				 ///<summary>金猪</summary>
 				  public static string UserFinanceItem_ItemAmount{
 				  get { return LangUtilities.GetString( "UserFinanceItem_ItemAmount"); }} 

				 ///<summary>OrderPayment</summary>
 				  public static string UserFinanceItem_OrderPayment{
 				  get { return LangUtilities.GetString( "UserFinanceItem_OrderPayment"); }} 

				 ///<summary>推广销售</summary>
 				  public static string UserFinanceItem_promoteAndSalesChannel{
 				  get { return LangUtilities.GetString( "UserFinanceItem_promoteAndSalesChannel"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserFinanceItem_ShopID{
 				  get { return LangUtilities.GetString( "UserFinanceItem_ShopID"); }} 

				 ///<summary>创建状态</summary>
 				  public static string UserFinanceItem_StatusId{
 				  get { return LangUtilities.GetString( "UserFinanceItem_StatusId"); }} 

				 ///<summary>外表ID</summary>
 				  public static string UserFinanceItem_TblKeyId{
 				  get { return LangUtilities.GetString( "UserFinanceItem_TblKeyId"); }} 

				 ///<summary>UserFinanceID</summary>
 				  public static string UserFinanceItem_UserFinanceID{
 				  get { return LangUtilities.GetString( "UserFinanceItem_UserFinanceID"); }} 

				 ///<summary>ID</summary>
 				  public static string UserFinanceItem_UserFinanceItemID{
 				  get { return LangUtilities.GetString( "UserFinanceItem_UserFinanceItemID"); }} 

				 ///<summary>UserId</summary>
 				  public static string UserFinanceItem_UserId{
 				  get { return LangUtilities.GetString( "UserFinanceItem_UserId"); }} 

				 ///<summary>会员收益</summary>
 				  public static string UserFinanceItemList_SubTitle{
 				  get { return LangUtilities.GetString( "UserFinanceItemList_SubTitle"); }} 

				 ///<summary>财务明细项</summary>
 				  public static string UserFinanceItemList_Title{
 				  get { return LangUtilities.GetString( "UserFinanceItemList_Title"); }} 

				 ///<summary>分享赚 分享成长</summary>
 				  public static string UserFinanceList_SubTitle{
 				  get { return LangUtilities.GetString( "UserFinanceList_SubTitle"); }} 

				 ///<summary>分享赚</summary>
 				  public static string UserFinanceList_Title{
 				  get { return LangUtilities.GetString( "UserFinanceList_Title"); }} 

				 ///<summary>地址</summary>
 				  public static string UserProfile_Address{
 				  get { return LangUtilities.GetString( "UserProfile_Address"); }} 

				 ///<summary>分发帐号</summary>
 				  public static string UserProfile_AsignAccountMgrIDs{
 				  get { return LangUtilities.GetString( "UserProfile_AsignAccountMgrIDs"); }} 

				 ///<summary>出生日期</summary>
 				  public static string UserProfile_Birthday{
 				  get { return LangUtilities.GetString( "UserProfile_Birthday"); }} 

				 ///<summary>城市</summary>
 				  public static string UserProfile_City{
 				  get { return LangUtilities.GetString( "UserProfile_City"); }} 

				 ///<summary>国家</summary>
 				  public static string UserProfile_Country{
 				  get { return LangUtilities.GetString( "UserProfile_Country"); }} 

				 ///<summary>创建日期</summary>
 				  public static string UserProfile_CreatedDate{
 				  get { return LangUtilities.GetString( "UserProfile_CreatedDate"); }} 

				 ///<summary>客戶跟進</summary>
 				  public static string UserProfile_Detail_CRMFollowUp{
 				  get { return LangUtilities.GetString( "UserProfile_Detail_CRMFollowUp"); }} 

				 ///<summary>个人资料</summary>
 				  public static string UserProfile_Detail_PersonalInfo{
 				  get { return LangUtilities.GetString( "UserProfile_Detail_PersonalInfo"); }} 

				 ///<summary>客户关系跟进</summary>
 				  public static string UserProfile_Detail_Subtitle{
 				  get { return LangUtilities.GetString( "UserProfile_Detail_Subtitle"); }} 

				 ///<summary>截断微信ID长度,只显示长度的一半,方便微信查找</summary>
 				  public static string UserProfile_Detail_WeChatID_Title{
 				  get { return LangUtilities.GetString( "UserProfile_Detail_WeChatID_Title"); }} 

				 ///<summary>县/区</summary>
 				  public static string UserProfile_District{
 				  get { return LangUtilities.GetString( "UserProfile_District"); }} 

				 ///<summary>Email</summary>
 				  public static string UserProfile_Email{
 				  get { return LangUtilities.GetString( "UserProfile_Email"); }} 

				 ///<summary>帳戶金額</summary>
 				  public static string UserProfile_FinanceAmount{
 				  get { return LangUtilities.GetString( "UserProfile_FinanceAmount"); }} 

				 ///<summary>姓名</summary>
 				  public static string UserProfile_FullName{
 				  get { return LangUtilities.GetString( "UserProfile_FullName"); }} 

				 ///<summary>性别</summary>
 				  public static string UserProfile_Gender {
 				  get { return LangUtilities.GetString( "UserProfile_Gender "); }} 

				 ///<summary>ID</summary>
 				  public static string UserProfile_ID{
 				  get { return LangUtilities.GetString( "UserProfile_ID"); }} 

				 ///<summary>拉黑</summary>
 				  public static string UserProfile_IsBlock{
 				  get { return LangUtilities.GetString( "UserProfile_IsBlock"); }} 

				 ///<summary>独占资源</summary>
 				  public static string UserProfile_IsMonopoly{
 				  get { return LangUtilities.GetString( "UserProfile_IsMonopoly"); }} 

				 ///<summary>数据库保存</summary>
 				  public static string UserProfile_IsSaveDB{
 				  get { return LangUtilities.GetString( "UserProfile_IsSaveDB"); }} 

				 ///<summary>截取部分微信ID作为数据记录存储：</summary>
 				  public static string UserProfile_JS_Detail_WeChatID_Tips{
 				  get { return LangUtilities.GetString( "UserProfile_JS_Detail_WeChatID_Tips"); }} 

				 ///<summary>昵称</summary>
 				  public static string UserProfile_NickName{
 				  get { return LangUtilities.GetString( "UserProfile_NickName"); }} 

				 ///<summary>OpenID</summary>
 				  public static string UserProfile_OpenID{
 				  get { return LangUtilities.GetString( "UserProfile_OpenID"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserProfile_OperatedDate{
 				  get { return LangUtilities.GetString( "UserProfile_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string UserProfile_OperatedUserName{
 				  get { return LangUtilities.GetString( "UserProfile_OperatedUserName"); }} 

				 ///<summary>ParentUserId</summary>
 				  public static string UserProfile_ParentUserId{
 				  get { return LangUtilities.GetString( "UserProfile_ParentUserId"); }} 

				 ///<summary>手机</summary>
 				  public static string UserProfile_PhoneNumber{
 				  get { return LangUtilities.GetString( "UserProfile_PhoneNumber"); }} 

				 ///<summary>量化积分</summary>
 				  public static string UserProfile_QuantizationScore{
 				  get { return LangUtilities.GetString( "UserProfile_QuantizationScore"); }} 

				 ///<summary>收货手机</summary>
 				  public static string UserProfile_RecievedPhoneNumber{
 				  get { return LangUtilities.GetString( "UserProfile_RecievedPhoneNumber"); }} 

				 ///<summary>备注</summary>
 				  public static string UserProfile_Remarks{
 				  get { return LangUtilities.GetString( "UserProfile_Remarks"); }} 

				 ///<summary>来源于资源文件</summary>
 				  public static string UserProfile_ResourceFile{
 				  get { return LangUtilities.GetString( "UserProfile_ResourceFile"); }} 

				 ///<summary>积分</summary>
 				  public static string UserProfile_Score{
 				  get { return LangUtilities.GetString( "UserProfile_Score"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserProfile_ShopID{
 				  get { return LangUtilities.GetString( "UserProfile_ShopID"); }} 

				 ///<summary>州/省</summary>
 				  public static string UserProfile_State{
 				  get { return LangUtilities.GetString( "UserProfile_State"); }} 

				 ///<summary>UserIcon</summary>
 				  public static string UserProfile_UserIcon{
 				  get { return LangUtilities.GetString( "UserProfile_UserIcon"); }} 

				 ///<summary>UserId</summary>
 				  public static string UserProfile_UserId{
 				  get { return LangUtilities.GetString( "UserProfile_UserId"); }} 

				 ///<summary>自定义标签</summary>
 				  public static string UserProfile_UserTagID{
 				  get { return LangUtilities.GetString( "UserProfile_UserTagID"); }} 

				 ///<summary>客户来源分类</summary>
 				  public static string UserProfile_UserTagID_select{
 				  get { return LangUtilities.GetString( "UserProfile_UserTagID_select"); }} 

				 ///<summary>联系资料</summary>
 				  public static string UserProfile_Views_Detail_ContactInfo{
 				  get { return LangUtilities.GetString( "UserProfile_Views_Detail_ContactInfo"); }} 

				 ///<summary>Vip等级ID</summary>
 				  public static string UserProfile_VipLevelID{
 				  get { return LangUtilities.GetString( "UserProfile_VipLevelID"); }} 

				 ///<summary>微信ID</summary>
 				  public static string UserProfile_WechatID{
 				  get { return LangUtilities.GetString( "UserProfile_WechatID"); }} 

				 ///<summary>创建日期</summary>
 				  public static string UserQuantFactor_CreatedDate{
 				  get { return LangUtilities.GetString( "UserQuantFactor_CreatedDate"); }} 

				 ///<summary>备注/跟进状态</summary>
 				  public static string UserQuantFactor_FactorNameRemarks{
 				  get { return LangUtilities.GetString( "UserQuantFactor_FactorNameRemarks"); }} 

				 ///<summary>ID</summary>
 				  public static string UserQuantFactor_ID{
 				  get { return LangUtilities.GetString( "UserQuantFactor_ID"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserQuantFactor_OperatedDate{
 				  get { return LangUtilities.GetString( "UserQuantFactor_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string UserQuantFactor_OperatedUserName{
 				  get { return LangUtilities.GetString( "UserQuantFactor_OperatedUserName"); }} 

				 ///<summary>量化因素ID</summary>
 				  public static string UserQuantFactor_QuantFactorID{
 				  get { return LangUtilities.GetString( "UserQuantFactor_QuantFactorID"); }} 

				 ///<summary>权重分</summary>
 				  public static string UserQuantFactor_Score{
 				  get { return LangUtilities.GetString( "UserQuantFactor_Score"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserQuantFactor_ShopID{
 				  get { return LangUtilities.GetString( "UserQuantFactor_ShopID"); }} 

				 ///<summary>量化权重因素管理</summary>
 				  public static string UserQuantFactor_Title{
 				  get { return LangUtilities.GetString( "UserQuantFactor_Title"); }} 

				 ///<summary>UserProfileID</summary>
 				  public static string UserQuantFactor_UserProfileID{
 				  get { return LangUtilities.GetString( "UserQuantFactor_UserProfileID"); }} 

				 ///<summary>备注项目</summary>
 				  public static string UserQuantFactorList_lable1{
 				  get { return LangUtilities.GetString( "UserQuantFactorList_lable1"); }} 

				 ///<summary>客户的量化列表</summary>
 				  public static string UserQuantFactorList_Title{
 				  get { return LangUtilities.GetString( "UserQuantFactorList_Title"); }} 

				 ///<summary>自定义标签ID</summary>
 				  public static string UserTag_TagID{
 				  get { return LangUtilities.GetString( "UserTag_TagID"); }} 

				 ///<summary>自定义标签名称</summary>
 				  public static string UserTag_TagName{
 				  get { return LangUtilities.GetString( "UserTag_TagName"); }} 

				 ///<summary>TableKeyID</summary>
 				  public static string UserTrace_InfoID{
 				  get { return LangUtilities.GetString( "UserTrace_InfoID"); }} 

				 ///<summary>跟踪ID</summary>
 				  public static string UserTrace_InfoTraceID{
 				  get { return LangUtilities.GetString( "UserTrace_InfoTraceID"); }} 

				 ///<summary>操作日期</summary>
 				  public static string UserTrace_OperatedDate{
 				  get { return LangUtilities.GetString( "UserTrace_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string UserTrace_OperatedUserName{
 				  get { return LangUtilities.GetString( "UserTrace_OperatedUserName"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string UserTrace_ShopID{
 				  get { return LangUtilities.GetString( "UserTrace_ShopID"); }} 

				 ///<summary>KeyID</summary>
 				  public static string UserTrace_TableKeyID{
 				  get { return LangUtilities.GetString( "UserTrace_TableKeyID"); }} 

				 ///<summary>UserId</summary>
 				  public static string UserTrace_UserId{
 				  get { return LangUtilities.GetString( "UserTrace_UserId"); }} 

				 ///<summary>跟踪ID</summary>
 				  public static string UserTrace_UserTraceID{
 				  get { return LangUtilities.GetString( "UserTrace_UserTraceID"); }} 

				 ///<summary>手机号码</summary>
 				  public static string VerifyPhoneNumberViewModel_PhoneNumber{
 				  get { return LangUtilities.GetString( "VerifyPhoneNumberViewModel_PhoneNumber"); }} 

				 ///<summary>添加渠</summary>
 				  public static string Views_GeneralUI_Add{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Add"); }} 

				 ///<summary>新 增</summary>
 				  public static string Views_GeneralUI_AddNew{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddNew"); }} 

				 ///<summary>新增成功</summary>
 				  public static string Views_GeneralUI_AddNewOk{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddNewOk"); }} 

				 ///<summary>笔名/作者(建议最多4个字.太多影响页面)</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_FillNickNameTitle{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_FillNickNameTitle"); }} 

				 ///<summary>填入笔名或</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_FilltheNickName{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_FilltheNickName"); }} 

				 ///<summary>不选择的情况下,信息详情不显示编辑简介</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_ShopStaffID_Title{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_ShopStaffID_Title"); }} 

				 ///<summary>是否在内容中首先显示标题图</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_ShowTitleThumbNail_Lanbel_title{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_ShowTitleThumbNail_Lanbel_title"); }} 

				 ///<summary>正确格式的url或空白不填</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_VideoUrl_placeHolder{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_VideoUrl_placeHolder"); }} 

				 ///<summary>视频连接,例如优酷/youtube等等上存视频的连接url</summary>
 				  public static string Views_GeneralUI_AddUpdateInfo_VideoUrl_title{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_AddUpdateInfo_VideoUrl_title"); }} 

				 ///<summary>整 理</summary>
 				  public static string Views_GeneralUI_Arrange{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Arrange"); }} 

				 ///<summary>人工智慧</summary>
 				  public static string Views_GeneralUI_ArtificialIntelligence{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ArtificialIntelligence"); }} 

				 ///<summary>审核</summary>
 				  public static string Views_GeneralUI_Audit{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Audit"); }} 

				 ///<summary>大数据</summary>
 				  public static string Views_GeneralUI_BigData{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_BigData"); }} 

				 ///<summary>拉 黑</summary>
 				  public static string Views_GeneralUI_Block{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Block"); }} 

				 ///<summary>浏 览</summary>
 				  public static string Views_GeneralUI_Browse{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Browse"); }} 

				 ///<summary>取消</summary>
 				  public static string Views_GeneralUI_Cancel{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Cancel"); }} 

				 ///<summary>商品类目管理</summary>
 				  public static string Views_GeneralUI_CateMgr{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CateMgr"); }} 

				 ///<summary>安防 闭路电视AI应用</summary>
 				  public static string Views_GeneralUI_CCTV{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CCTV"); }} 

				 ///<summary>更 改</summary>
 				  public static string Views_GeneralUI_Change{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Change"); }} 

				 ///<summary>更改密码</summary>
 				  public static string Views_GeneralUI_ChangePassword{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ChangePassword"); }} 

				 ///<summary>点击此处变更图片</summary>
 				  public static string Views_GeneralUI_ChangeThepicture{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ChangeThepicture"); }} 

				 ///<summary>更改为</summary>
 				  public static string Views_GeneralUI_ChangeTo{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ChangeTo"); }} 

				 ///<summary>云端监控</summary>
 				  public static string Views_GeneralUI_CloudMonitoring{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CloudMonitoring"); }} 

				 ///<summary>云端监控人工智慧</summary>
 				  public static string Views_GeneralUI_CloudMonitoringAI{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CloudMonitoringAI"); }} 

				 ///<summary>获取验证码</summary>
 				  public static string Views_GeneralUI_Code{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Code"); }} 

				 ///<summary>确定</summary>
 				  public static string Views_GeneralUI_Comfirm{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Comfirm"); }} 

				 ///<summary>信汇互联科技专注互联网电子商务</summary>
 				  public static string Views_GeneralUI_CompanyName{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CompanyName"); }} 

				 ///<summary>确认订单</summary>
 				  public static string Views_GeneralUI_ConfirmOrder{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ConfirmOrder"); }} 

				 ///<summary>内容库</summary>
 				  public static string Views_GeneralUI_ContentLabrary{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ContentLabrary"); }} 

				 ///<summary>创 建</summary>
 				  public static string Views_GeneralUI_Create{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Create"); }} 

				 ///<summary>客户关系管理</summary>
 				  public static string Views_GeneralUI_CRM{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_CRM"); }} 

				 ///<summary>按时间排序</summary>
 				  public static string Views_GeneralUI_Datetime{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Datetime"); }} 

				 ///<summary>YYYY-MM-DD hh:mm</summary>
 				  public static string Views_GeneralUI_DateTimeFormat{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DateTimeFormat"); }} 

				 ///<summary>默认为根类目</summary>
 				  public static string Views_GeneralUI_DefaultRoot{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DefaultRoot"); }} 

				 ///<summary>默认根类关键词=0</summary>
 				  public static string Views_GeneralUI_DefaultRootValue{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DefaultRootValue"); }} 

				 ///<summary>刪 除</summary>
 				  public static string Views_GeneralUI_Delete{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Delete"); }} 

				 ///<summary>删除成功</summary>
 				  public static string Views_GeneralUI_DeleteOK{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DeleteOK"); }} 

				 ///<summary>详情</summary>
 				  public static string Views_GeneralUI_Details{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Details"); }} 

				 ///<summary>请勿重复提交</summary>
 				  public static string Views_GeneralUI_DontRepeateSubmit{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DontRepeateSubmit"); }} 

				 ///<summary>下载</summary>
 				  public static string Views_GeneralUI_DownLoad{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DownLoad"); }} 

				 ///<summary>驾驶行为智能监视</summary>
 				  public static string Views_GeneralUI_DrivingBehavior{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_DrivingBehavior"); }} 

				 ///<summary>编 辑</summary>
 				  public static string Views_GeneralUI_Edit{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Edit"); }} 

				 ///<summary>查 找 </summary>
 				  public static string Views_GeneralUI_Find{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Find"); }} 

				 ///<summary>最顶级</summary>
 				  public static string Views_GeneralUI_FirstLevel{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_FirstLevel"); }} 

				 ///<summary>主页</summary>
 				  public static string Views_GeneralUI_Home{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Home"); }} 

				 ///<summary>HTML5模板</summary>
 				  public static string Views_GeneralUI_Html5Template{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Html5Template"); }} 

				 ///<summary>输入关键词</summary>
 				  public static string Views_GeneralUI_InputKeyWord{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InputKeyWord"); }} 

				 ///<summary>物联网</summary>
 				  public static string Views_GeneralUI_InternetofThings{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InternetofThings"); }} 

				 ///<summary>代码无效。</summary>
 				  public static string Views_GeneralUI_InvalidCode{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidCode"); }} 

				 ///<summary>数据输入无效</summary>
 				  public static string Views_GeneralUI_InvalidDataInput{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidDataInput"); }} 

				 ///<summary>无效的Email</summary>
 				  public static string Views_GeneralUI_InvalidEmail{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidEmail"); }} 

				 ///<summary>无效的登录尝试。</summary>
 				  public static string Views_GeneralUI_InvalidLogin{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidLogin"); }} 

				 ///<summary>无效的手机号码</summary>
 				  public static string Views_GeneralUI_InvalidMobilePhone{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidMobilePhone"); }} 

				 ///<summary>无效的手机登录尝试。</summary>
 				  public static string Views_GeneralUI_InvalidPhoneNumberLogin{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_InvalidPhoneNumberLogin"); }} 

				 ///<summary>关键词</summary>
 				  public static string Views_GeneralUI_KeyWord{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_KeyWord"); }} 

				 ///<summary>上一级</summary>
 				  public static string Views_GeneralUI_LastLevel{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_LastLevel"); }} 

				 ///<summary>上月分享赚</summary>
 				  public static string Views_GeneralUI_LastMonthTotalAmount{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_LastMonthTotalAmount"); }} 

				 ///<summary>链接</summary>
 				  public static string Views_GeneralUI_Link{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Link"); }} 

				 ///<summary>列 表</summary>
 				  public static string Views_GeneralUI_List{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_List"); }} 

				 ///<summary>正在加载</summary>
 				  public static string Views_GeneralUI_Loading{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Loading"); }} 

				 ///<summary>登 录</summary>
 				  public static string Views_GeneralUI_Login{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Login"); }} 

				 ///<summary>登录ID</summary>
 				  public static string Views_GeneralUI_LoginID{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_LoginID"); }} 

				 ///<summary>登录账号</summary>
 				  public static string Views_GeneralUI_LoginName{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_LoginName"); }} 

				 ///<summary>店铺內主分类默认0</summary>
 				  public static string Views_GeneralUI_MainCategoryDefaults0{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_MainCategoryDefaults0"); }} 

				 ///<summary>菜单</summary>
 				  public static string Views_GeneralUI_Manu{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Manu"); }} 

				 ///<summary>会员中心</summary>
 				  public static string Views_GeneralUI_MemberCenter{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_MemberCenter"); }} 

				 ///<summary>管理平台</summary>
 				  public static string Views_GeneralUI_Mgr_Platform{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Mgr_Platform"); }} 

				 ///<summary>关键词富文本HTML5模板</summary>
 				  public static string Views_GeneralUI_ModalSeoHtml_Title_text{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ModalSeoHtml_Title_text"); }} 

				 ///<summary>无库存</summary>
 				  public static string Views_GeneralUI_NoStock{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_NoStock"); }} 

				 ///<summary>规则: 一个用户仅管理一个店铺</summary>
 				  public static string Views_GeneralUI_onlyoneShop{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_onlyoneShop"); }} 

				 ///<summary>操作失败</summary>
 				  public static string Views_GeneralUI_OperateFail{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OperateFail"); }} 

				 ///<summary>操作提示</summary>
 				  public static string Views_GeneralUI_OperateInfo{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OperateInfo"); }} 

				 ///<summary>按{0}排序</summary>
 				  public static string Views_GeneralUI_OrderBy{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OrderBy"); }} 

				 ///<summary>按时间排序</summary>
 				  public static string Views_GeneralUI_OrderByDatetime{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OrderByDatetime"); }} 

				 ///<summary>订单详情</summary>
 				  public static string Views_GeneralUI_OrderDetails{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OrderDetails"); }} 

				 ///<summary>订单号</summary>
 				  public static string Views_GeneralUI_OrderId{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OrderId"); }} 

				 ///<summary>缺 货</summary>
 				  public static string Views_GeneralUI_OutOfStock{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_OutOfStock"); }} 

				 ///<summary>密 码</summary>
 				  public static string Views_GeneralUI_Password{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Password"); }} 

				 ///<summary>密码不对哦 ！</summary>
 				  public static string Views_GeneralUI_PasswordIswrong{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_PasswordIswrong"); }} 

				 ///<summary>请把获取的HTML5模板复制粘贴到描述HTML5编辑器</summary>
 				  public static string Views_GeneralUI_PasteTheObtainedHTML5{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_PasteTheObtainedHTML5"); }} 

				 ///<summary>重要操作，确定吗？</summary>
 				  public static string Views_GeneralUI_Pleasecomfirm{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Pleasecomfirm"); }} 

				 ///<summary>且慢,喝杯茶先吧</summary>
 				  public static string Views_GeneralUI_Pleasewait{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Pleasewait"); }} 

				 ///<summary>等等,哈!</summary>
 				  public static string Views_GeneralUI_PleaseWait2{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_PleaseWait2"); }} 

				 ///<summary>数量</summary>
 				  public static string Views_GeneralUI_Quantity{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Quantity"); }} 

				 ///<summary>刷 新</summary>
 				  public static string Views_GeneralUI_Reflash{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Reflash"); }} 

				 ///<summary>注 册</summary>
 				  public static string Views_GeneralUI_Register{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Register"); }} 

				 ///<summary>相关文件</summary>
 				  public static string Views_GeneralUI_RelateFile{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_RelateFile"); }} 

				 ///<summary>备注</summary>
 				  public static string Views_GeneralUI_Remarks{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Remarks"); }} 

				 ///<summary>移 除</summary>
 				  public static string Views_GeneralUI_Remove{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Remove"); }} 

				 ///<summary>生成</summary>
 				  public static string Views_GeneralUI_Render{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Render"); }} 

				 ///<summary>重 置</summary>
 				  public static string Views_GeneralUI_Reset{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Reset"); }} 

				 ///<summary>重置密码</summary>
 				  public static string Views_GeneralUI_ResetPassword{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ResetPassword"); }} 

				 ///<summary>返 回</summary>
 				  public static string Views_GeneralUI_Return{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Return"); }} 

				 ///<summary>返回结果</summary>
 				  public static string Views_GeneralUI_ReturnResult{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ReturnResult"); }} 

				 ///<summary>返回列表</summary>
 				  public static string Views_GeneralUI_ReturnToList{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ReturnToList"); }} 

				 ///<summary>富文本</summary>
 				  public static string Views_GeneralUI_RichText{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_RichText"); }} 

				 ///<summary>角色权限</summary>
 				  public static string Views_GeneralUI_RolePermission{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_RolePermission"); }} 

				 ///<summary>根關鍵詞</summary>
 				  public static string Views_GeneralUI_RootKeyWord{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_RootKeyWord"); }} 

				 ///<summary>售价</summary>
 				  public static string Views_GeneralUI_SalePrice{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SalePrice"); }} 

				 ///<summary>保存</summary>
 				  public static string Views_GeneralUI_SaveChanges{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SaveChanges"); }} 

				 ///<summary>成功保存！</summary>
 				  public static string Views_GeneralUI_SavedSuccessfully{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SavedSuccessfully"); }} 

				 ///<summary>搜 索</summary>
 				  public static string Views_GeneralUI_Search{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Search"); }} 

				 ///<summary>已选</summary>
 				  public static string Views_GeneralUI_Selected{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Selected"); }} 

				 ///<summary>请选择父级关键词</summary>
 				  public static string Views_GeneralUI_SelectParentkeyword{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SelectParentkeyword"); }} 

				 ///<summary>选好了</summary>
 				  public static string Views_GeneralUI_seletedOK{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_seletedOK"); }} 

				 ///<summary>发生服务器错误</summary>
 				  public static string Views_GeneralUI_ServerError{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ServerError"); }} 

				 ///<summary>设置密码</summary>
 				  public static string Views_GeneralUI_SetPassword{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SetPassword"); }} 

				 ///<summary>分享赚 分享成长</summary>
 				  public static string Views_GeneralUI_Share_earning_share_growth{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Share_earning_share_growth"); }} 

				 ///<summary>智慧城市</summary>
 				  public static string Views_GeneralUI_SmartCity{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SmartCity"); }} 

				 ///<summary>按时间排序</summary>
 				  public static string Views_GeneralUI_SortByTime{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SortByTime"); }} 

				 ///<summary>库 存</summary>
 				  public static string Views_GeneralUI_Stock{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Stock"); }} 

				 ///<summary>提 交</summary>
 				  public static string Views_GeneralUI_Submit{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Submit"); }} 

				 ///<summary>提交数据失败</summary>
 				  public static string Views_GeneralUI_SubmitError{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_SubmitError"); }} 

				 ///<summary>系统</summary>
 				  public static string Views_GeneralUI_System{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_System"); }} 

				 ///<summary>本月分享赚</summary>
 				  public static string Views_GeneralUI_ThisMonthTotalAmount{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_ThisMonthTotalAmount"); }} 

				 ///<summary>Top50排名</summary>
 				  public static string Views_GeneralUI_Top50{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Top50"); }} 

				 ///<summary>售 价 ：</summary>
 				  public static string Views_GeneralUI_TradePrice{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_TradePrice"); }} 

				 ///<summary>更 新</summary>
 				  public static string Views_GeneralUI_Update{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Update"); }} 

				 ///<summary>更新失败</summary>
 				  public static string Views_GeneralUI_UpdateFail{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UpdateFail"); }} 

				 ///<summary>更新成功</summary>
 				  public static string Views_GeneralUI_UpdateOK{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UpdateOK"); }} 

				 ///<summary>上传完成</summary>
 				  public static string Views_GeneralUI_UploadConpleted{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UploadConpleted"); }} 

				 ///<summary>上传出错</summary>
 				  public static string Views_GeneralUI_UploadError{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UploadError"); }} 

				 ///<summary>上存文件</summary>
 				  public static string Views_GeneralUI_UploadFile{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UploadFile"); }} 

				 ///<summary>等待上传...</summary>
 				  public static string Views_GeneralUI_Uploading{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_Uploading"); }} 

				 ///<summary>上存到服務器</summary>
 				  public static string Views_GeneralUI_UploadToServer{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UploadToServer"); }} 

				 ///<summary>正确格式的url或空白不填</summary>
 				  public static string Views_GeneralUI_UrlFormatOrBlank{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_UrlFormatOrBlank"); }} 

				 ///<summary>视频分析</summary>
 				  public static string Views_GeneralUI_VideoAnalysis{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_VideoAnalysis"); }} 

				 ///<summary>微信付款購買</summary>
 				  public static string Views_GeneralUI_WeChatPay{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_WeChatPay"); }} 

				 ///<summary>提 现</summary>
 				  public static string Views_GeneralUI_withdraw{
 				  get { return LangUtilities.GetString( "Views_GeneralUI_withdraw"); }} 

				 ///<summary>新增商品类目</summary>
 				  public static string Views_ProdCateV2_Addproductcategory{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Addproductcategory"); }} 

				 ///<summary>删除成功，将无法通过此类目查询商品归类</summary>
 				  public static string Views_ProdCateV2_Index_DelSeuccTips{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_DelSeuccTips"); }} 

				 ///<summary>是否为交易属性</summary>
 				  public static string Views_ProdCateV2_Index_IsTradeProp{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_IsTradeProp"); }} 

				 ///<summary>属性名称</summary>
 				  public static string Views_ProdCateV2_Index_myModalheader_lbl_PropertiesName{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_myModalheader_lbl_PropertiesName"); }} 

				 ///<summary>类目的属性与值</summary>
 				  public static string Views_ProdCateV2_Index_NameAndValue{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_NameAndValue"); }} 

				 ///<summary>属性名称（文字或字母）</summary>
 				  public static string Views_ProdCateV2_Index_NameFormat{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_NameFormat"); }} 

				 ///<summary>属性名称更改成功！</summary>
 				  public static string Views_ProdCateV2_Index_NameModiSucc{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_NameModiSucc"); }} 

				 ///<summary>新类目名称：</summary>
 				  public static string Views_ProdCateV2_Index_NewCategoryname{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_NewCategoryname"); }} 

				 ///<summary>原类目名称：</summary>
 				  public static string Views_ProdCateV2_Index_Originalcategoryname{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_Originalcategoryname"); }} 

				 ///<summary>图片形式显示</summary>
 				  public static string Views_ProdCateV2_Index_ShowPicture{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_ShowPicture"); }} 

				 ///<summary>填入必须要更改类目名称！</summary>
 				  public static string Views_ProdCateV2_Index_span_upd1{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_span_upd1"); }} 

				 ///<summary>生态类目</summary>
 				  public static string Views_ProdCateV2_Index_SubTitle{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_SubTitle"); }} 

				 ///<summary>商品类目管理</summary>
 				  public static string Views_ProdCateV2_Index_Title{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_Title"); }} 

				 ///<summary>更新商品类目</summary>
 				  public static string Views_ProdCateV2_Index_UpdCate{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Index_UpdCate"); }} 

				 ///<summary>必须填入类目名称！</summary>
 				  public static string Views_ProdCateV2_MustFillCategoryName{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_MustFillCategoryName"); }} 

				 ///<summary>必须填入新增子类目名称！</summary>
 				  public static string Views_ProdCateV2_NewSubcateRequire{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_NewSubcateRequire"); }} 

				 ///<summary>当前类目没有属性定义</summary>
 				  public static string Views_ProdCateV2_No_PropertiesValueName_Record{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_No_PropertiesValueName_Record"); }} 

				 ///<summary>商品父类目</summary>
 				  public static string Views_ProdCateV2_ParentCategory{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_ParentCategory"); }} 

				 ///<summary>文字或字母格式</summary>
 				  public static string Views_ProdCateV2_ProdcatenameFormate{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_ProdcatenameFormate"); }} 

				 ///<summary>已存在重复！</summary>
 				  public static string Views_ProdCateV2_ProdcateRepeate{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_ProdcateRepeate"); }} 

				 ///<summary>子类目</summary>
 				  public static string Views_ProdCateV2_Subcategory{
 				  get { return LangUtilities.GetString( "Views_ProdCateV2_Subcategory"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string VipLevel_ShopID{
 				  get { return LangUtilities.GetString( "VipLevel_ShopID"); }} 

				 ///<summary>Vip等级ID</summary>
 				  public static string VipLevel_VipLevelID{
 				  get { return LangUtilities.GetString( "VipLevel_VipLevelID"); }} 

				 ///<summary>Vip等级名称</summary>
 				  public static string VipLevel_VipLevelName{
 				  get { return LangUtilities.GetString( "VipLevel_VipLevelName"); }} 

				 ///<summary>令牌</summary>
 				  public static string WeiXin_access_token{
 				  get { return LangUtilities.GetString( "WeiXin_access_token"); }} 

				 ///<summary>AppID</summary>
 				  public static string WeiXin_appId{
 				  get { return LangUtilities.GetString( "WeiXin_appId"); }} 

				 ///<summary>创建日期</summary>
 				  public static string WeiXin_CreatedDate{
 				  get { return LangUtilities.GetString( "WeiXin_CreatedDate"); }} 

				 ///<summary>超时</summary>
 				  public static string WeiXin_expires_in{
 				  get { return LangUtilities.GetString( "WeiXin_expires_in"); }} 

				 ///<summary>更新日期</summary>
 				  public static string WeiXin_lastupdate{
 				  get { return LangUtilities.GetString( "WeiXin_lastupdate"); }} 

				 ///<summary>操作日期</summary>
 				  public static string WeiXin_OperatedDate{
 				  get { return LangUtilities.GetString( "WeiXin_OperatedDate"); }} 

				 ///<summary>操作用户</summary>
 				  public static string WeiXin_OperatedUserName{
 				  get { return LangUtilities.GetString( "WeiXin_OperatedUserName"); }} 

				 ///<summary>secret</summary>
 				  public static string WeiXin_secret{
 				  get { return LangUtilities.GetString( "WeiXin_secret"); }} 

				 ///<summary>店铺ID</summary>
 				  public static string WeiXin_ShopID{
 				  get { return LangUtilities.GetString( "WeiXin_ShopID"); }} 

				 ///<summary>票据</summary>
 				  public static string WeiXin_ticket{
 				  get { return LangUtilities.GetString( "WeiXin_ticket"); }} 

				 ///<summary>票据时效</summary>
 				  public static string WeiXin_ticket_expires_in{
 				  get { return LangUtilities.GetString( "WeiXin_ticket_expires_in"); }} 

        #endregion
         
    }

}
