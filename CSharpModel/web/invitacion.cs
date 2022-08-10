using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class invitacion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            n1EspectaculoId = false;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A1EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A4LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A3PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A3PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A4LugarId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A7TipoEspectaculoId = (short)(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."));
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A7TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            n1EspectaculoId = false;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A1EspectaculoId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            n1EspectaculoId = false;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A1EspectaculoId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7InvitacionId = (short)(NumberUtil.Val( GetPar( "InvitacionId"), "."));
               AssignAttri("", false, "AV7InvitacionId", StringUtil.LTrimStr( (decimal)(AV7InvitacionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-161416", 0) ;
            }
            Form.Meta.addItem("description", "Invitacion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtInvitacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public invitacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public invitacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_InvitacionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7InvitacionId = aP1_InvitacionId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Invitacion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvitacionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtInvitacionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24InvitacionId), 4, 0, ",", "")), StringUtil.LTrim( ((edtInvitacionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A24InvitacionId), "ZZZ9") : context.localUtil.Format( (decimal)(A24InvitacionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvitacionFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtInvitacionFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtInvitacionFecha_Internalname, context.localUtil.Format(A25InvitacionFecha, "99/99/99"), context.localUtil.Format( A25InvitacionFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_bitmap( context, edtInvitacionFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtInvitacionFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invitacion.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisName_Internalname, "Pais Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtInvitacionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtInvitacionName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtInvitacionName_Internalname, A45InvitacionName, StringUtil.RTrim( context.localUtil.Format( A45InvitacionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtInvitacionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtInvitacionName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Invitacion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Espectaculo Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Espectaculo Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A16EspectaculoFecha, "99/99/99"), context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Invitacion.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarName_Internalname, "Lugar Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorId_Internalname, "Lugar Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Invitacion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_27_Internalname, sImgUrl, imgprompt_27_Link, "", "", context.GetTheme( ), imgprompt_27_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorName_Internalname, "Lugar Sector Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarSectorName_Internalname, A28LugarSectorName, StringUtil.RTrim( context.localUtil.Format( A28LugarSectorName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorDisponibles_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorDisponibles_Internalname, "Lugar Sector Disponibles", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9") : context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorDisponibles_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorDisponibles_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoName_Internalname, "Tipo Espectaculo Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Invitacion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z24InvitacionId = (short)(context.localUtil.CToN( cgiGet( "Z24InvitacionId"), ",", "."));
               Z25InvitacionFecha = context.localUtil.CToD( cgiGet( "Z25InvitacionFecha"), 0);
               Z45InvitacionName = cgiGet( "Z45InvitacionName");
               n45InvitacionName = (String.IsNullOrEmpty(StringUtil.RTrim( A45InvitacionName)) ? true : false);
               Z1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ",", "."));
               Z27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( "Z27LugarSectorId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "N1EspectaculoId"), ",", "."));
               N27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( "N27LugarSectorId"), ",", "."));
               A29LugarSectorCantidad = (short)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDAD"), ",", "."));
               A37LugarSectorVendidas = (short)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS"), ",", "."));
               n37LugarSectorVendidas = false;
               AV7InvitacionId = (short)(context.localUtil.CToN( cgiGet( "vINVITACIONID"), ",", "."));
               AV11Insert_EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."));
               AV14Insert_LugarSectorId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_LUGARSECTORID"), ",", "."));
               A4LugarId = (short)(context.localUtil.CToN( cgiGet( "LUGARID"), ",", "."));
               A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "TIPOESPECTACULOID"), ",", "."));
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( "PAISID"), ",", "."));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A24InvitacionId = (short)(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ",", "."));
               AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtInvitacionFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Invitacion Fecha"}), 1, "INVITACIONFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtInvitacionFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A25InvitacionFecha = DateTime.MinValue;
                  AssignAttri("", false, "A25InvitacionFecha", context.localUtil.Format(A25InvitacionFecha, "99/99/99"));
               }
               else
               {
                  A25InvitacionFecha = context.localUtil.CToD( cgiGet( edtInvitacionFecha_Internalname), 2);
                  AssignAttri("", false, "A25InvitacionFecha", context.localUtil.Format(A25InvitacionFecha, "99/99/99"));
               }
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
               A45InvitacionName = cgiGet( edtInvitacionName_Internalname);
               n45InvitacionName = false;
               AssignAttri("", false, "A45InvitacionName", A45InvitacionName);
               n45InvitacionName = (String.IsNullOrEmpty(StringUtil.RTrim( A45InvitacionName)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1EspectaculoId = 0;
                  n1EspectaculoId = false;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               }
               else
               {
                  A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
                  n1EspectaculoId = false;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               }
               A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
               AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
               A16EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
               AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               A5LugarName = cgiGet( edtLugarName_Internalname);
               AssignAttri("", false, "A5LugarName", A5LugarName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LUGARSECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A27LugarSectorId = 0;
                  n27LugarSectorId = false;
                  AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
               }
               else
               {
                  A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
                  n27LugarSectorId = false;
                  AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
               }
               A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
               AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
               A38LugarSectorDisponibles = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorDisponibles_Internalname), ",", "."));
               AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
               A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
               AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
               A24InvitacionId = (short)(context.localUtil.CToN( cgiGet( edtInvitacionId_Internalname), ",", "."));
               AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
               forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A24InvitacionId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A24InvitacionId != Z24InvitacionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("invitacion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A24InvitacionId = (short)(NumberUtil.Val( GetPar( "InvitacionId"), "."));
                  AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode10 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode10;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound10 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "INVITACIONID");
                        AnyError = 1;
                        GX_FocusControl = edtInvitacionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12092 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0910( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0910( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_090( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0910( ) ;
            }
            else
            {
               CheckExtendedTable0910( ) ;
               CloseExtendedTableCursors0910( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
         AV14Insert_LugarSectorId = 0;
         AssignAttri("", false, "AV14Insert_LugarSectorId", StringUtil.LTrimStr( (decimal)(AV14Insert_LugarSectorId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV11Insert_EspectaculoId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "LugarSectorId") == 0 )
               {
                  AV14Insert_LugarSectorId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_LugarSectorId", StringUtil.LTrimStr( (decimal)(AV14Insert_LugarSectorId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwinvitacion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z25InvitacionFecha = T00093_A25InvitacionFecha[0];
               Z45InvitacionName = T00093_A45InvitacionName[0];
               Z1EspectaculoId = T00093_A1EspectaculoId[0];
               Z27LugarSectorId = T00093_A27LugarSectorId[0];
            }
            else
            {
               Z25InvitacionFecha = A25InvitacionFecha;
               Z45InvitacionName = A45InvitacionName;
               Z1EspectaculoId = A1EspectaculoId;
               Z27LugarSectorId = A27LugarSectorId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z24InvitacionId = A24InvitacionId;
            Z25InvitacionFecha = A25InvitacionFecha;
            Z45InvitacionName = A45InvitacionName;
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z3PaisId = A3PaisId;
            Z5LugarName = A5LugarName;
            Z6PaisName = A6PaisName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
            Z28LugarSectorName = A28LugarSectorName;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
         }
      }

      protected void standaloneNotModal( )
      {
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00f0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_27_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00g1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"LUGARSECTORID"+"'), id:'"+"LUGARSECTORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7InvitacionId) )
         {
            A24InvitacionId = AV7InvitacionId;
            AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtEspectaculoId_Enabled = 1;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_LugarSectorId) )
         {
            edtLugarSectorId_Enabled = 0;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), true);
         }
         else
         {
            edtLugarSectorId_Enabled = 1;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_LugarSectorId) )
         {
            A27LugarSectorId = AV14Insert_LugarSectorId;
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            A1EspectaculoId = AV11Insert_EspectaculoId;
            n1EspectaculoId = false;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV15Pgmname = "Invitacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00094 */
            pr_default.execute(2, new Object[] {n1EspectaculoId, A1EspectaculoId});
            A4LugarId = T00094_A4LugarId[0];
            A7TipoEspectaculoId = T00094_A7TipoEspectaculoId[0];
            A2EspectaculoName = T00094_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T00094_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            pr_default.close(2);
            /* Using cursor T00096 */
            pr_default.execute(4, new Object[] {A4LugarId});
            A3PaisId = T00096_A3PaisId[0];
            A5LugarName = T00096_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(4);
            /* Using cursor T00097 */
            pr_default.execute(5, new Object[] {A3PaisId});
            A6PaisName = T00097_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(5);
            /* Using cursor T00099 */
            pr_default.execute(7, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
            A28LugarSectorName = T00099_A28LugarSectorName[0];
            AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
            A29LugarSectorCantidad = T00099_A29LugarSectorCantidad[0];
            pr_default.close(7);
            /* Using cursor T00098 */
            pr_default.execute(6, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T00098_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(6);
            /* Using cursor T000911 */
            pr_default.execute(8, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A37LugarSectorVendidas = T000911_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = T000911_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
               AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
            }
            pr_default.close(8);
            A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
            AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
         }
      }

      protected void Load0910( )
      {
         /* Using cursor T000913 */
         pr_default.execute(9, new Object[] {A24InvitacionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound10 = 1;
            A4LugarId = T000913_A4LugarId[0];
            A3PaisId = T000913_A3PaisId[0];
            A7TipoEspectaculoId = T000913_A7TipoEspectaculoId[0];
            A25InvitacionFecha = T000913_A25InvitacionFecha[0];
            AssignAttri("", false, "A25InvitacionFecha", context.localUtil.Format(A25InvitacionFecha, "99/99/99"));
            A6PaisName = T000913_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A45InvitacionName = T000913_A45InvitacionName[0];
            n45InvitacionName = T000913_n45InvitacionName[0];
            AssignAttri("", false, "A45InvitacionName", A45InvitacionName);
            A2EspectaculoName = T000913_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000913_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A5LugarName = T000913_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A28LugarSectorName = T000913_A28LugarSectorName[0];
            AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
            A8TipoEspectaculoName = T000913_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A29LugarSectorCantidad = T000913_A29LugarSectorCantidad[0];
            A1EspectaculoId = T000913_A1EspectaculoId[0];
            n1EspectaculoId = T000913_n1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = T000913_A27LugarSectorId[0];
            n27LugarSectorId = T000913_n27LugarSectorId[0];
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            A37LugarSectorVendidas = T000913_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000913_n37LugarSectorVendidas[0];
            ZM0910( -15) ;
         }
         pr_default.close(9);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
         AV15Pgmname = "Invitacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
      }

      protected void CheckExtendedTable0910( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "Invitacion";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! ( (DateTime.MinValue==A25InvitacionFecha) || ( DateTimeUtil.ResetTime ( A25InvitacionFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Invitacion Fecha fuera de rango", "OutOfRange", 1, "INVITACIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtInvitacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {n1EspectaculoId, A1EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4LugarId = T00094_A4LugarId[0];
         A7TipoEspectaculoId = T00094_A7TipoEspectaculoId[0];
         A2EspectaculoName = T00094_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = T00094_A16EspectaculoFecha[0];
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         pr_default.close(2);
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A3PaisId = T00096_A3PaisId[0];
         A5LugarName = T00096_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         pr_default.close(4);
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T00097_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(5);
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T00099_A28LugarSectorName[0];
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A29LugarSectorCantidad = T00099_A29LugarSectorCantidad[0];
         pr_default.close(7);
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T00098_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         pr_default.close(6);
         if ( DateTimeUtil.ResetTime ( A25InvitacionFecha ) > DateTimeUtil.ResetTime ( A16EspectaculoFecha ) )
         {
            GX_msglist.addItem("Fecha invalida", 1, "INVITACIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtInvitacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T000911 */
         pr_default.execute(8, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A37LugarSectorVendidas = T000911_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000911_n37LugarSectorVendidas[0];
         }
         else
         {
            nIsDirty_10 = 1;
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
            AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         }
         pr_default.close(8);
         nIsDirty_10 = 1;
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
         if ( A38LugarSectorDisponibles < 1 )
         {
            GX_msglist.addItem("No hay lugares disponibles", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(6);
         pr_default.close(3);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( short A1EspectaculoId )
      {
         /* Using cursor T000914 */
         pr_default.execute(10, new Object[] {n1EspectaculoId, A1EspectaculoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A4LugarId = T000914_A4LugarId[0];
         A7TipoEspectaculoId = T000914_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000914_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = T000914_A16EspectaculoFecha[0];
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A2EspectaculoName)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A16EspectaculoFecha, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_18( short A4LugarId )
      {
         /* Using cursor T000915 */
         pr_default.execute(11, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A3PaisId = T000915_A3PaisId[0];
         A5LugarName = T000915_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A5LugarName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_19( short A3PaisId )
      {
         /* Using cursor T000916 */
         pr_default.execute(12, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000916_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_21( short A4LugarId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000917 */
         pr_default.execute(13, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000917_A28LugarSectorName[0];
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A29LugarSectorCantidad = T000917_A29LugarSectorCantidad[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28LugarSectorName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_20( short A7TipoEspectaculoId )
      {
         /* Using cursor T000918 */
         pr_default.execute(14, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000918_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8TipoEspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_17( short A1EspectaculoId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000919 */
         pr_default.execute(15, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_22( short A1EspectaculoId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000921 */
         pr_default.execute(16, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A37LugarSectorVendidas = T000921_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000921_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
            AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void GetKey0910( )
      {
         /* Using cursor T000922 */
         pr_default.execute(17, new Object[] {A24InvitacionId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A24InvitacionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 15) ;
            RcdFound10 = 1;
            A24InvitacionId = T00093_A24InvitacionId[0];
            AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
            A25InvitacionFecha = T00093_A25InvitacionFecha[0];
            AssignAttri("", false, "A25InvitacionFecha", context.localUtil.Format(A25InvitacionFecha, "99/99/99"));
            A45InvitacionName = T00093_A45InvitacionName[0];
            n45InvitacionName = T00093_n45InvitacionName[0];
            AssignAttri("", false, "A45InvitacionName", A45InvitacionName);
            A1EspectaculoId = T00093_A1EspectaculoId[0];
            n1EspectaculoId = T00093_n1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = T00093_A27LugarSectorId[0];
            n27LugarSectorId = T00093_n27LugarSectorId[0];
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            Z24InvitacionId = A24InvitacionId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0910( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0910( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0910( ) ;
         if ( RcdFound10 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound10 = 0;
         /* Using cursor T000923 */
         pr_default.execute(18, new Object[] {A24InvitacionId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            while ( (pr_default.getStatus(18) != 101) && ( ( T000923_A24InvitacionId[0] < A24InvitacionId ) ) )
            {
               pr_default.readNext(18);
            }
            if ( (pr_default.getStatus(18) != 101) && ( ( T000923_A24InvitacionId[0] > A24InvitacionId ) ) )
            {
               A24InvitacionId = T000923_A24InvitacionId[0];
               AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(18);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000924 */
         pr_default.execute(19, new Object[] {A24InvitacionId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            while ( (pr_default.getStatus(19) != 101) && ( ( T000924_A24InvitacionId[0] > A24InvitacionId ) ) )
            {
               pr_default.readNext(19);
            }
            if ( (pr_default.getStatus(19) != 101) && ( ( T000924_A24InvitacionId[0] < A24InvitacionId ) ) )
            {
               A24InvitacionId = T000924_A24InvitacionId[0];
               AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(19);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0910( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtInvitacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0910( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A24InvitacionId != Z24InvitacionId )
               {
                  A24InvitacionId = Z24InvitacionId;
                  AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "INVITACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtInvitacionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtInvitacionFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0910( ) ;
                  GX_FocusControl = edtInvitacionFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A24InvitacionId != Z24InvitacionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtInvitacionFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0910( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "INVITACIONID");
                     AnyError = 1;
                     GX_FocusControl = edtInvitacionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtInvitacionFecha_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0910( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A24InvitacionId != Z24InvitacionId )
         {
            A24InvitacionId = Z24InvitacionId;
            AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "INVITACIONID");
            AnyError = 1;
            GX_FocusControl = edtInvitacionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtInvitacionFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A24InvitacionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z25InvitacionFecha ) != DateTimeUtil.ResetTime ( T00092_A25InvitacionFecha[0] ) ) || ( StringUtil.StrCmp(Z45InvitacionName, T00092_A45InvitacionName[0]) != 0 ) || ( Z1EspectaculoId != T00092_A1EspectaculoId[0] ) || ( Z27LugarSectorId != T00092_A27LugarSectorId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z25InvitacionFecha ) != DateTimeUtil.ResetTime ( T00092_A25InvitacionFecha[0] ) )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"InvitacionFecha");
                  GXUtil.WriteLogRaw("Old: ",Z25InvitacionFecha);
                  GXUtil.WriteLogRaw("Current: ",T00092_A25InvitacionFecha[0]);
               }
               if ( StringUtil.StrCmp(Z45InvitacionName, T00092_A45InvitacionName[0]) != 0 )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"InvitacionName");
                  GXUtil.WriteLogRaw("Old: ",Z45InvitacionName);
                  GXUtil.WriteLogRaw("Current: ",T00092_A45InvitacionName[0]);
               }
               if ( Z1EspectaculoId != T00092_A1EspectaculoId[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z1EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A1EspectaculoId[0]);
               }
               if ( Z27LugarSectorId != T00092_A27LugarSectorId[0] )
               {
                  GXUtil.WriteLog("invitacion:[seudo value changed for attri]"+"LugarSectorId");
                  GXUtil.WriteLogRaw("Old: ",Z27LugarSectorId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A27LugarSectorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Invitacion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000925 */
                     pr_default.execute(20, new Object[] {A25InvitacionFecha, n45InvitacionName, A45InvitacionName, n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
                     A24InvitacionId = T000925_A24InvitacionId[0];
                     AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000926 */
                     pr_default.execute(21, new Object[] {A25InvitacionFecha, n45InvitacionName, A45InvitacionName, n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId, A24InvitacionId});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("Invitacion");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Invitacion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000927 */
                  pr_default.execute(22, new Object[] {A24InvitacionId});
                  pr_default.close(22);
                  dsDefault.SmartCacheProvider.SetUpdated("Invitacion");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Invitacion";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000928 */
            pr_default.execute(23, new Object[] {n1EspectaculoId, A1EspectaculoId});
            A4LugarId = T000928_A4LugarId[0];
            A7TipoEspectaculoId = T000928_A7TipoEspectaculoId[0];
            A2EspectaculoName = T000928_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000928_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            pr_default.close(23);
            /* Using cursor T000929 */
            pr_default.execute(24, new Object[] {A4LugarId});
            A3PaisId = T000929_A3PaisId[0];
            A5LugarName = T000929_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(24);
            /* Using cursor T000930 */
            pr_default.execute(25, new Object[] {A3PaisId});
            A6PaisName = T000930_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(25);
            /* Using cursor T000931 */
            pr_default.execute(26, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000931_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(26);
            /* Using cursor T000932 */
            pr_default.execute(27, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
            A28LugarSectorName = T000932_A28LugarSectorName[0];
            AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
            A29LugarSectorCantidad = T000932_A29LugarSectorCantidad[0];
            pr_default.close(27);
            /* Using cursor T000934 */
            pr_default.execute(28, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               A37LugarSectorVendidas = T000934_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = T000934_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
               AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
            }
            pr_default.close(28);
            A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
            AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0910( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(27);
            pr_default.close(28);
            context.CommitDataStores("invitacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(25);
            pr_default.close(26);
            pr_default.close(27);
            pr_default.close(28);
            context.RollbackDataStores("invitacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0910( )
      {
         /* Scan By routine */
         /* Using cursor T000935 */
         pr_default.execute(29);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound10 = 1;
            A24InvitacionId = T000935_A24InvitacionId[0];
            AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound10 = 1;
            A24InvitacionId = T000935_A24InvitacionId[0];
            AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
         edtInvitacionId_Enabled = 0;
         AssignProp("", false, edtInvitacionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionId_Enabled), 5, 0), true);
         edtInvitacionFecha_Enabled = 0;
         AssignProp("", false, edtInvitacionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionFecha_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtInvitacionName_Enabled = 0;
         AssignProp("", false, edtInvitacionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtInvitacionName_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoName_Enabled = 0;
         AssignProp("", false, edtEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoName_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), true);
         edtLugarSectorName_Enabled = 0;
         AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), true);
         edtLugarSectorDisponibles_Enabled = 0;
         AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), true);
         edtTipoEspectaculoName_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228923411385", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Invitacion");
         forbiddenHiddens.Add("InvitacionId", context.localUtil.Format( (decimal)(A24InvitacionId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("invitacion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z24InvitacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24InvitacionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z25InvitacionFecha", context.localUtil.DToC( Z25InvitacionFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z45InvitacionName", Z45InvitacionName);
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z27LugarSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N27LugarSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORCANTIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORVENDIDAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINVITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7InvitacionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vINVITACIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7InvitacionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_LugarSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("invitacion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7InvitacionId,4,0))}, new string[] {"Gx_mode","InvitacionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Invitacion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Invitacion" ;
      }

      protected void InitializeNonKey0910( )
      {
         A7TipoEspectaculoId = 0;
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A1EspectaculoId = 0;
         n1EspectaculoId = false;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A27LugarSectorId = 0;
         n27LugarSectorId = false;
         AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
         A25InvitacionFecha = DateTime.MinValue;
         AssignAttri("", false, "A25InvitacionFecha", context.localUtil.Format(A25InvitacionFecha, "99/99/99"));
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A45InvitacionName = "";
         n45InvitacionName = false;
         AssignAttri("", false, "A45InvitacionName", A45InvitacionName);
         n45InvitacionName = (String.IsNullOrEmpty(StringUtil.RTrim( A45InvitacionName)) ? true : false);
         A2EspectaculoName = "";
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A28LugarSectorName = "";
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A38LugarSectorDisponibles = 0;
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
         A8TipoEspectaculoName = "";
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         A29LugarSectorCantidad = 0;
         AssignAttri("", false, "A29LugarSectorCantidad", StringUtil.LTrimStr( (decimal)(A29LugarSectorCantidad), 4, 0));
         A37LugarSectorVendidas = 0;
         n37LugarSectorVendidas = false;
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         Z25InvitacionFecha = DateTime.MinValue;
         Z45InvitacionName = "";
         Z1EspectaculoId = 0;
         Z27LugarSectorId = 0;
      }

      protected void InitAll0910( )
      {
         A24InvitacionId = 0;
         AssignAttri("", false, "A24InvitacionId", StringUtil.LTrimStr( (decimal)(A24InvitacionId), 4, 0));
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228923411391", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("invitacion.js", "?20228923411391", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtInvitacionId_Internalname = "INVITACIONID";
         edtInvitacionFecha_Internalname = "INVITACIONFECHA";
         edtPaisName_Internalname = "PAISNAME";
         edtInvitacionName_Internalname = "INVITACIONNAME";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoName_Internalname = "ESPECTACULONAME";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtLugarName_Internalname = "LUGARNAME";
         edtLugarSectorId_Internalname = "LUGARSECTORID";
         edtLugarSectorName_Internalname = "LUGARSECTORNAME";
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES";
         edtTipoEspectaculoName_Internalname = "TIPOESPECTACULONAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_27_Internalname = "PROMPT_27";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Invitacion";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtLugarSectorDisponibles_Jsonclick = "";
         edtLugarSectorDisponibles_Enabled = 0;
         edtLugarSectorName_Jsonclick = "";
         edtLugarSectorName_Enabled = 0;
         imgprompt_27_Visible = 1;
         imgprompt_27_Link = "";
         edtLugarSectorId_Jsonclick = "";
         edtLugarSectorId_Enabled = 1;
         edtLugarName_Jsonclick = "";
         edtLugarName_Enabled = 0;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 1;
         edtInvitacionName_Jsonclick = "";
         edtInvitacionName_Enabled = 1;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         edtInvitacionFecha_Jsonclick = "";
         edtInvitacionFecha_Enabled = 1;
         edtInvitacionId_Jsonclick = "";
         edtInvitacionId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Espectaculoid( )
      {
         n1EspectaculoId = false;
         /* Using cursor T000928 */
         pr_default.execute(23, new Object[] {n1EspectaculoId, A1EspectaculoId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A4LugarId = T000928_A4LugarId[0];
         A7TipoEspectaculoId = T000928_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000928_A2EspectaculoName[0];
         A16EspectaculoFecha = T000928_A16EspectaculoFecha[0];
         pr_default.close(23);
         /* Using cursor T000929 */
         pr_default.execute(24, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A3PaisId = T000929_A3PaisId[0];
         A5LugarName = T000929_A5LugarName[0];
         pr_default.close(24);
         /* Using cursor T000930 */
         pr_default.execute(25, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000930_A6PaisName[0];
         pr_default.close(25);
         /* Using cursor T000931 */
         pr_default.execute(26, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000931_A8TipoEspectaculoName[0];
         pr_default.close(26);
         if ( DateTimeUtil.ResetTime ( A25InvitacionFecha ) > DateTimeUtil.ResetTime ( A16EspectaculoFecha ) )
         {
            GX_msglist.addItem("Fecha invalida", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")));
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A5LugarName", A5LugarName);
         AssignAttri("", false, "A6PaisName", A6PaisName);
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
      }

      public void Valid_Lugarsectorid( )
      {
         n1EspectaculoId = false;
         n27LugarSectorId = false;
         n37LugarSectorVendidas = false;
         /* Using cursor T000936 */
         pr_default.execute(30, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         pr_default.close(30);
         /* Using cursor T000932 */
         pr_default.execute(27, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         A28LugarSectorName = T000932_A28LugarSectorName[0];
         A29LugarSectorCantidad = T000932_A29LugarSectorCantidad[0];
         pr_default.close(27);
         /* Using cursor T000934 */
         pr_default.execute(28, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            A37LugarSectorVendidas = T000934_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000934_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(28);
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         if ( A38LugarSectorDisponibles < 1 )
         {
            GX_msglist.addItem("No hay lugares disponibles", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         AssignAttri("", false, "A29LugarSectorCantidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")));
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7InvitacionId',fld:'vINVITACIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7InvitacionId',fld:'vINVITACIONID',pic:'ZZZ9',hsh:true},{av:'A24InvitacionId',fld:'INVITACIONID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12092',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_INVITACIONID","{handler:'Valid_Invitacionid',iparms:[]");
         setEventMetadata("VALID_INVITACIONID",",oparms:[]}");
         setEventMetadata("VALID_INVITACIONFECHA","{handler:'Valid_Invitacionfecha',iparms:[]");
         setEventMetadata("VALID_INVITACIONFECHA",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A25InvitacionFecha',fld:'INVITACIONFECHA',pic:''},{av:'A16EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A16EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A27LugarSectorId',fld:'LUGARSECTORID',pic:'ZZZ9'},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A29LugarSectorCantidad',fld:'LUGARSECTORCANTIDAD',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'},{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''}]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A29LugarSectorCantidad',fld:'LUGARSECTORCANTIDAD',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_LUGARSECTORDISPONIBLES","{handler:'Valid_Lugarsectordisponibles',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORDISPONIBLES",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(30);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z25InvitacionFecha = DateTime.MinValue;
         Z45InvitacionName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A25InvitacionFecha = DateTime.MinValue;
         A6PaisName = "";
         A45InvitacionName = "";
         sImgUrl = "";
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A5LugarName = "";
         A28LugarSectorName = "";
         A8TipoEspectaculoName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode10 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z5LugarName = "";
         Z6PaisName = "";
         Z8TipoEspectaculoName = "";
         Z28LugarSectorName = "";
         T00094_A4LugarId = new short[1] ;
         T00094_A7TipoEspectaculoId = new short[1] ;
         T00094_A2EspectaculoName = new string[] {""} ;
         T00094_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00096_A3PaisId = new short[1] ;
         T00096_A5LugarName = new string[] {""} ;
         T00097_A6PaisName = new string[] {""} ;
         T00099_A28LugarSectorName = new string[] {""} ;
         T00099_A29LugarSectorCantidad = new short[1] ;
         T00098_A8TipoEspectaculoName = new string[] {""} ;
         T000911_A37LugarSectorVendidas = new short[1] ;
         T000911_n37LugarSectorVendidas = new bool[] {false} ;
         T000913_A4LugarId = new short[1] ;
         T000913_A3PaisId = new short[1] ;
         T000913_A7TipoEspectaculoId = new short[1] ;
         T000913_A24InvitacionId = new short[1] ;
         T000913_A25InvitacionFecha = new DateTime[] {DateTime.MinValue} ;
         T000913_A6PaisName = new string[] {""} ;
         T000913_A45InvitacionName = new string[] {""} ;
         T000913_n45InvitacionName = new bool[] {false} ;
         T000913_A2EspectaculoName = new string[] {""} ;
         T000913_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000913_A5LugarName = new string[] {""} ;
         T000913_A28LugarSectorName = new string[] {""} ;
         T000913_A8TipoEspectaculoName = new string[] {""} ;
         T000913_A29LugarSectorCantidad = new short[1] ;
         T000913_A1EspectaculoId = new short[1] ;
         T000913_n1EspectaculoId = new bool[] {false} ;
         T000913_A27LugarSectorId = new short[1] ;
         T000913_n27LugarSectorId = new bool[] {false} ;
         T000913_A37LugarSectorVendidas = new short[1] ;
         T000913_n37LugarSectorVendidas = new bool[] {false} ;
         T00095_A1EspectaculoId = new short[1] ;
         T00095_n1EspectaculoId = new bool[] {false} ;
         T000914_A4LugarId = new short[1] ;
         T000914_A7TipoEspectaculoId = new short[1] ;
         T000914_A2EspectaculoName = new string[] {""} ;
         T000914_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000915_A3PaisId = new short[1] ;
         T000915_A5LugarName = new string[] {""} ;
         T000916_A6PaisName = new string[] {""} ;
         T000917_A28LugarSectorName = new string[] {""} ;
         T000917_A29LugarSectorCantidad = new short[1] ;
         T000918_A8TipoEspectaculoName = new string[] {""} ;
         T000919_A1EspectaculoId = new short[1] ;
         T000919_n1EspectaculoId = new bool[] {false} ;
         T000921_A37LugarSectorVendidas = new short[1] ;
         T000921_n37LugarSectorVendidas = new bool[] {false} ;
         T000922_A24InvitacionId = new short[1] ;
         T00093_A24InvitacionId = new short[1] ;
         T00093_A25InvitacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A45InvitacionName = new string[] {""} ;
         T00093_n45InvitacionName = new bool[] {false} ;
         T00093_A1EspectaculoId = new short[1] ;
         T00093_n1EspectaculoId = new bool[] {false} ;
         T00093_A27LugarSectorId = new short[1] ;
         T00093_n27LugarSectorId = new bool[] {false} ;
         T000923_A24InvitacionId = new short[1] ;
         T000924_A24InvitacionId = new short[1] ;
         T00092_A24InvitacionId = new short[1] ;
         T00092_A25InvitacionFecha = new DateTime[] {DateTime.MinValue} ;
         T00092_A45InvitacionName = new string[] {""} ;
         T00092_n45InvitacionName = new bool[] {false} ;
         T00092_A1EspectaculoId = new short[1] ;
         T00092_n1EspectaculoId = new bool[] {false} ;
         T00092_A27LugarSectorId = new short[1] ;
         T00092_n27LugarSectorId = new bool[] {false} ;
         T000925_A24InvitacionId = new short[1] ;
         T000928_A4LugarId = new short[1] ;
         T000928_A7TipoEspectaculoId = new short[1] ;
         T000928_A2EspectaculoName = new string[] {""} ;
         T000928_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000929_A3PaisId = new short[1] ;
         T000929_A5LugarName = new string[] {""} ;
         T000930_A6PaisName = new string[] {""} ;
         T000931_A8TipoEspectaculoName = new string[] {""} ;
         T000932_A28LugarSectorName = new string[] {""} ;
         T000932_A29LugarSectorCantidad = new short[1] ;
         T000934_A37LugarSectorVendidas = new short[1] ;
         T000934_n37LugarSectorVendidas = new bool[] {false} ;
         T000935_A24InvitacionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000936_A1EspectaculoId = new short[1] ;
         T000936_n1EspectaculoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.invitacion__default(),
            new Object[][] {
                new Object[] {
               T00092_A24InvitacionId, T00092_A25InvitacionFecha, T00092_A45InvitacionName, T00092_n45InvitacionName, T00092_A1EspectaculoId, T00092_A27LugarSectorId
               }
               , new Object[] {
               T00093_A24InvitacionId, T00093_A25InvitacionFecha, T00093_A45InvitacionName, T00093_n45InvitacionName, T00093_A1EspectaculoId, T00093_A27LugarSectorId
               }
               , new Object[] {
               T00094_A4LugarId, T00094_A7TipoEspectaculoId, T00094_A2EspectaculoName, T00094_A16EspectaculoFecha
               }
               , new Object[] {
               T00095_A1EspectaculoId
               }
               , new Object[] {
               T00096_A3PaisId, T00096_A5LugarName
               }
               , new Object[] {
               T00097_A6PaisName
               }
               , new Object[] {
               T00098_A8TipoEspectaculoName
               }
               , new Object[] {
               T00099_A28LugarSectorName, T00099_A29LugarSectorCantidad
               }
               , new Object[] {
               T000911_A37LugarSectorVendidas, T000911_n37LugarSectorVendidas
               }
               , new Object[] {
               T000913_A4LugarId, T000913_A3PaisId, T000913_A7TipoEspectaculoId, T000913_A24InvitacionId, T000913_A25InvitacionFecha, T000913_A6PaisName, T000913_A45InvitacionName, T000913_n45InvitacionName, T000913_A2EspectaculoName, T000913_A16EspectaculoFecha,
               T000913_A5LugarName, T000913_A28LugarSectorName, T000913_A8TipoEspectaculoName, T000913_A29LugarSectorCantidad, T000913_A1EspectaculoId, T000913_n1EspectaculoId, T000913_A27LugarSectorId, T000913_n27LugarSectorId, T000913_A37LugarSectorVendidas, T000913_n37LugarSectorVendidas
               }
               , new Object[] {
               T000914_A4LugarId, T000914_A7TipoEspectaculoId, T000914_A2EspectaculoName, T000914_A16EspectaculoFecha
               }
               , new Object[] {
               T000915_A3PaisId, T000915_A5LugarName
               }
               , new Object[] {
               T000916_A6PaisName
               }
               , new Object[] {
               T000917_A28LugarSectorName, T000917_A29LugarSectorCantidad
               }
               , new Object[] {
               T000918_A8TipoEspectaculoName
               }
               , new Object[] {
               T000919_A1EspectaculoId
               }
               , new Object[] {
               T000921_A37LugarSectorVendidas, T000921_n37LugarSectorVendidas
               }
               , new Object[] {
               T000922_A24InvitacionId
               }
               , new Object[] {
               T000923_A24InvitacionId
               }
               , new Object[] {
               T000924_A24InvitacionId
               }
               , new Object[] {
               T000925_A24InvitacionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000928_A4LugarId, T000928_A7TipoEspectaculoId, T000928_A2EspectaculoName, T000928_A16EspectaculoFecha
               }
               , new Object[] {
               T000929_A3PaisId, T000929_A5LugarName
               }
               , new Object[] {
               T000930_A6PaisName
               }
               , new Object[] {
               T000931_A8TipoEspectaculoName
               }
               , new Object[] {
               T000932_A28LugarSectorName, T000932_A29LugarSectorCantidad
               }
               , new Object[] {
               T000934_A37LugarSectorVendidas, T000934_n37LugarSectorVendidas
               }
               , new Object[] {
               T000935_A24InvitacionId
               }
               , new Object[] {
               T000936_A1EspectaculoId
               }
            }
         );
         AV15Pgmname = "Invitacion";
      }

      private short wcpOAV7InvitacionId ;
      private short Z24InvitacionId ;
      private short Z1EspectaculoId ;
      private short Z27LugarSectorId ;
      private short N1EspectaculoId ;
      private short N27LugarSectorId ;
      private short GxWebError ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short A27LugarSectorId ;
      private short A7TipoEspectaculoId ;
      private short AV7InvitacionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A24InvitacionId ;
      private short A38LugarSectorDisponibles ;
      private short A29LugarSectorCantidad ;
      private short A37LugarSectorVendidas ;
      private short AV11Insert_EspectaculoId ;
      private short AV14Insert_LugarSectorId ;
      private short RcdFound10 ;
      private short GX_JID ;
      private short Z4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short Z3PaisId ;
      private short Z29LugarSectorCantidad ;
      private short Z37LugarSectorVendidas ;
      private short Gx_BScreen ;
      private short nIsDirty_10 ;
      private short gxajaxcallmode ;
      private short Z38LugarSectorDisponibles ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtInvitacionId_Enabled ;
      private int edtInvitacionFecha_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtInvitacionName_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtEspectaculoName_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtLugarSectorId_Enabled ;
      private int imgprompt_27_Visible ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorDisponibles_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtInvitacionFecha_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtInvitacionId_Internalname ;
      private string edtInvitacionId_Jsonclick ;
      private string edtInvitacionFecha_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtInvitacionName_Internalname ;
      private string edtInvitacionName_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Jsonclick ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorId_Jsonclick ;
      private string imgprompt_27_Internalname ;
      private string imgprompt_27_Link ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorDisponibles_Internalname ;
      private string edtLugarSectorDisponibles_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode10 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z25InvitacionFecha ;
      private DateTime A25InvitacionFecha ;
      private DateTime A16EspectaculoFecha ;
      private DateTime Z16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1EspectaculoId ;
      private bool n27LugarSectorId ;
      private bool wbErr ;
      private bool n45InvitacionName ;
      private bool n37LugarSectorVendidas ;
      private bool returnInSub ;
      private string Z45InvitacionName ;
      private string A6PaisName ;
      private string A45InvitacionName ;
      private string A2EspectaculoName ;
      private string A5LugarName ;
      private string A28LugarSectorName ;
      private string A8TipoEspectaculoName ;
      private string Z2EspectaculoName ;
      private string Z5LugarName ;
      private string Z6PaisName ;
      private string Z8TipoEspectaculoName ;
      private string Z28LugarSectorName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00094_A4LugarId ;
      private short[] T00094_A7TipoEspectaculoId ;
      private string[] T00094_A2EspectaculoName ;
      private DateTime[] T00094_A16EspectaculoFecha ;
      private short[] T00096_A3PaisId ;
      private string[] T00096_A5LugarName ;
      private string[] T00097_A6PaisName ;
      private string[] T00099_A28LugarSectorName ;
      private short[] T00099_A29LugarSectorCantidad ;
      private string[] T00098_A8TipoEspectaculoName ;
      private short[] T000911_A37LugarSectorVendidas ;
      private bool[] T000911_n37LugarSectorVendidas ;
      private short[] T000913_A4LugarId ;
      private short[] T000913_A3PaisId ;
      private short[] T000913_A7TipoEspectaculoId ;
      private short[] T000913_A24InvitacionId ;
      private DateTime[] T000913_A25InvitacionFecha ;
      private string[] T000913_A6PaisName ;
      private string[] T000913_A45InvitacionName ;
      private bool[] T000913_n45InvitacionName ;
      private string[] T000913_A2EspectaculoName ;
      private DateTime[] T000913_A16EspectaculoFecha ;
      private string[] T000913_A5LugarName ;
      private string[] T000913_A28LugarSectorName ;
      private string[] T000913_A8TipoEspectaculoName ;
      private short[] T000913_A29LugarSectorCantidad ;
      private short[] T000913_A1EspectaculoId ;
      private bool[] T000913_n1EspectaculoId ;
      private short[] T000913_A27LugarSectorId ;
      private bool[] T000913_n27LugarSectorId ;
      private short[] T000913_A37LugarSectorVendidas ;
      private bool[] T000913_n37LugarSectorVendidas ;
      private short[] T00095_A1EspectaculoId ;
      private bool[] T00095_n1EspectaculoId ;
      private short[] T000914_A4LugarId ;
      private short[] T000914_A7TipoEspectaculoId ;
      private string[] T000914_A2EspectaculoName ;
      private DateTime[] T000914_A16EspectaculoFecha ;
      private short[] T000915_A3PaisId ;
      private string[] T000915_A5LugarName ;
      private string[] T000916_A6PaisName ;
      private string[] T000917_A28LugarSectorName ;
      private short[] T000917_A29LugarSectorCantidad ;
      private string[] T000918_A8TipoEspectaculoName ;
      private short[] T000919_A1EspectaculoId ;
      private bool[] T000919_n1EspectaculoId ;
      private short[] T000921_A37LugarSectorVendidas ;
      private bool[] T000921_n37LugarSectorVendidas ;
      private short[] T000922_A24InvitacionId ;
      private short[] T00093_A24InvitacionId ;
      private DateTime[] T00093_A25InvitacionFecha ;
      private string[] T00093_A45InvitacionName ;
      private bool[] T00093_n45InvitacionName ;
      private short[] T00093_A1EspectaculoId ;
      private bool[] T00093_n1EspectaculoId ;
      private short[] T00093_A27LugarSectorId ;
      private bool[] T00093_n27LugarSectorId ;
      private short[] T000923_A24InvitacionId ;
      private short[] T000924_A24InvitacionId ;
      private short[] T00092_A24InvitacionId ;
      private DateTime[] T00092_A25InvitacionFecha ;
      private string[] T00092_A45InvitacionName ;
      private bool[] T00092_n45InvitacionName ;
      private short[] T00092_A1EspectaculoId ;
      private bool[] T00092_n1EspectaculoId ;
      private short[] T00092_A27LugarSectorId ;
      private bool[] T00092_n27LugarSectorId ;
      private short[] T000925_A24InvitacionId ;
      private short[] T000928_A4LugarId ;
      private short[] T000928_A7TipoEspectaculoId ;
      private string[] T000928_A2EspectaculoName ;
      private DateTime[] T000928_A16EspectaculoFecha ;
      private short[] T000929_A3PaisId ;
      private string[] T000929_A5LugarName ;
      private string[] T000930_A6PaisName ;
      private string[] T000931_A8TipoEspectaculoName ;
      private string[] T000932_A28LugarSectorName ;
      private short[] T000932_A29LugarSectorCantidad ;
      private short[] T000934_A37LugarSectorVendidas ;
      private bool[] T000934_n37LugarSectorVendidas ;
      private short[] T000935_A24InvitacionId ;
      private short[] T000936_A1EspectaculoId ;
      private bool[] T000936_n1EspectaculoId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class invitacion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000913;
          prmT000913 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00094;
          prmT00094 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00096;
          prmT00096 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00097;
          prmT00097 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00099;
          prmT00099 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00098;
          prmT00098 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00095;
          prmT00095 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000911;
          prmT000911 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000914;
          prmT000914 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000915;
          prmT000915 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000916;
          prmT000916 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000917;
          prmT000917 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000918;
          prmT000918 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000919;
          prmT000919 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000921;
          prmT000921 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000922;
          prmT000922 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00093;
          prmT00093 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000923;
          prmT000923 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000924;
          prmT000924 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT00092;
          prmT00092 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000925;
          prmT000925 = new Object[] {
          new ParDef("@InvitacionFecha",GXType.Date,8,0) ,
          new ParDef("@InvitacionName",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000926;
          prmT000926 = new Object[] {
          new ParDef("@InvitacionFecha",GXType.Date,8,0) ,
          new ParDef("@InvitacionName",GXType.NVarChar,40,0){Nullable=true} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000927;
          prmT000927 = new Object[] {
          new ParDef("@InvitacionId",GXType.Int16,4,0)
          };
          Object[] prmT000935;
          prmT000935 = new Object[] {
          };
          Object[] prmT000928;
          prmT000928 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000929;
          prmT000929 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000930;
          prmT000930 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000931;
          prmT000931 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000936;
          prmT000936 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000932;
          prmT000932 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000934;
          prmT000934 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00092", "SELECT [InvitacionId], [InvitacionFecha], [InvitacionName], [EspectaculoId], [LugarSectorId] FROM [Invitacion] WITH (UPDLOCK) WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00093", "SELECT [InvitacionId], [InvitacionFecha], [InvitacionName], [EspectaculoId], [LugarSectorId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00094", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00095", "SELECT [EspectaculoId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00096", "SELECT [PaisId], [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00097", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00098", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00099", "SELECT [LugarSectorName], [LugarSectorCantidad] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000911", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000913", "SELECT T2.[LugarId], T3.[PaisId], T2.[TipoEspectaculoId], TM1.[InvitacionId], TM1.[InvitacionFecha], T4.[PaisName], TM1.[InvitacionName], T2.[EspectaculoName], T2.[EspectaculoFecha], T3.[LugarName], T6.[LugarSectorName], T5.[TipoEspectaculoName], T6.[LugarSectorCantidad], TM1.[EspectaculoId], TM1.[LugarSectorId], COALESCE( T7.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (((((([Invitacion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [Lugar] T3 ON T3.[LugarId] = T2.[LugarId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisId]) INNER JOIN [TipoEspectaculo] T5 ON T5.[TipoEspectaculoId] = T2.[TipoEspectaculoId]) LEFT JOIN [LugarSector] T6 ON T6.[LugarId] = T2.[LugarId] AND T6.[LugarSectorId] = TM1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T7 ON T7.[EspectaculoId] = TM1.[EspectaculoId] AND T7.[LugarSectorId] = TM1.[LugarSectorId]) WHERE TM1.[InvitacionId] = @InvitacionId ORDER BY TM1.[InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000914", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000915", "SELECT [PaisId], [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000916", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000916,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000917", "SELECT [LugarSectorName], [LugarSectorCantidad] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000917,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000918", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000918,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000919", "SELECT [EspectaculoId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000919,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000921", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000921,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000922", "SELECT [InvitacionId] FROM [Invitacion] WHERE [InvitacionId] = @InvitacionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000922,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000923", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] > @InvitacionId) ORDER BY [InvitacionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000923,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000924", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE ( [InvitacionId] < @InvitacionId) ORDER BY [InvitacionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000924,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000925", "INSERT INTO [Invitacion]([InvitacionFecha], [InvitacionName], [EspectaculoId], [LugarSectorId]) VALUES(@InvitacionFecha, @InvitacionName, @EspectaculoId, @LugarSectorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000925,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000926", "UPDATE [Invitacion] SET [InvitacionFecha]=@InvitacionFecha, [InvitacionName]=@InvitacionName, [EspectaculoId]=@EspectaculoId, [LugarSectorId]=@LugarSectorId  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000926)
             ,new CursorDef("T000927", "DELETE FROM [Invitacion]  WHERE [InvitacionId] = @InvitacionId", GxErrorMask.GX_NOMASK,prmT000927)
             ,new CursorDef("T000928", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000928,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000929", "SELECT [PaisId], [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000929,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000930", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000930,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000931", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000931,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000932", "SELECT [LugarSectorName], [LugarSectorCantidad] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000932,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000934", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000934,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000935", "SELECT [InvitacionId] FROM [Invitacion] ORDER BY [InvitacionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000935,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000936", "SELECT [EspectaculoId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000936,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((string[]) buf[12])[0] = rslt.getVarchar(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                ((bool[]) buf[17])[0] = rslt.wasNull(15);
                ((short[]) buf[18])[0] = rslt.getShort(16);
                ((bool[]) buf[19])[0] = rslt.wasNull(16);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 28 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
