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
   public class espectaculo : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A4LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A3PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A3PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A7TipoEspectaculoId = (short)(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."));
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A7TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A4LugarId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A27LugarSectorId, A1EspectaculoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridespectaculo_lugarsector") == 0 )
         {
            gxnrGridespectaculo_lugarsector_newrow_invoke( ) ;
            return  ;
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
               AV7EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
               AssignAttri("", false, "AV7EspectaculoId", StringUtil.LTrimStr( (decimal)(AV7EspectaculoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Espectaculo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridespectaculo_lugarsector_newrow_invoke( )
      {
         nRC_GXsfl_83 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_83"), "."));
         nGXsfl_83_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_83_idx"), "."));
         sGXsfl_83_idx = GetPar( "sGXsfl_83_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridespectaculo_lugarsector_newrow( ) ;
         /* End function gxnrGridespectaculo_lugarsector_newrow_invoke */
      }

      public espectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public espectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EspectaculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EspectaculoId = aP1_EspectaculoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Espectaculo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A16EspectaculoFecha, "99/99/99"), context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Pais Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarId_Internalname, "Lugar Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoId_Internalname, "Tipo Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_7_Internalname, sImgUrl, imgprompt_7_Link, "", "", context.GetTheme( ), imgprompt_7_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLugarsectortable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelugarsector_Internalname, "Lugar Sector", "", "", lblTitlelugarsector_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridespectaculo_lugarsector( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgEspectaculoImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A26EspectaculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen));
         GxWebStd.gx_bitmap( context, imgEspectaculoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgEspectaculoImagen_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "", "", "", 0, A26EspectaculoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         AssignProp("", false, imgEspectaculoImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen)), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A26EspectaculoImagen_IsBlob), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridespectaculo_lugarsector( )
      {
         /*  Grid Control  */
         StartGridControl83( ) ;
         nGXsfl_83_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount13 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_13 = 1;
               ScanStart0113( ) ;
               while ( RcdFound13 != 0 )
               {
                  init_level_properties13( ) ;
                  getByPrimaryKey0113( ) ;
                  AddRow0113( ) ;
                  ScanNext0113( ) ;
               }
               ScanEnd0113( ) ;
               nBlankRcdCount13 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0113( ) ;
            standaloneModal0113( ) ;
            sMode13 = Gx_mode;
            while ( nGXsfl_83_idx < nRC_GXsfl_83 )
            {
               bGXsfl_83_Refreshing = true;
               ReadRow0113( ) ;
               edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorCantidadAsientos_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorCantidadAsientos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorEstadoSector_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorEstadoSector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorVendidas_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               edtLugarSectorDisponibles_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), !bGXsfl_83_Refreshing);
               imgprompt_4_Link = cgiGet( "PROMPT_27_"+sGXsfl_83_idx+"Link");
               if ( ( nRcdExists_13 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0113( ) ;
               }
               SendRow0113( ) ;
               bGXsfl_83_Refreshing = false;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount13 = 5;
            nRcdExists_13 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0113( ) ;
               while ( RcdFound13 != 0 )
               {
                  sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8313( ) ;
                  init_level_properties13( ) ;
                  standaloneNotModal0113( ) ;
                  getByPrimaryKey0113( ) ;
                  standaloneModal0113( ) ;
                  AddRow0113( ) ;
                  ScanNext0113( ) ;
               }
               ScanEnd0113( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode13 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8313( ) ;
            InitAll0113( ) ;
            init_level_properties13( ) ;
            nRcdExists_13 = 0;
            nIsMod_13 = 0;
            nRcdDeleted_13 = 0;
            nBlankRcdCount13 = (short)(nBlankRcdUsr13+nBlankRcdCount13);
            fRowAdded = 0;
            while ( nBlankRcdCount13 > 0 )
            {
               standaloneNotModal0113( ) ;
               standaloneModal0113( ) ;
               AddRow0113( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtLugarSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount13 = (short)(nBlankRcdCount13-1);
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridespectaculo_lugarsectorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridespectaculo_lugarsector", Gridespectaculo_lugarsectorContainer, subGridespectaculo_lugarsector_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_lugarsectorContainerData", Gridespectaculo_lugarsectorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_lugarsectorContainerData"+"V", Gridespectaculo_lugarsectorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridespectaculo_lugarsectorContainerData"+"V"+"\" value='"+Gridespectaculo_lugarsectorContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11012 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ",", "."));
               Z2EspectaculoName = cgiGet( "Z2EspectaculoName");
               Z16EspectaculoFecha = context.localUtil.CToD( cgiGet( "Z16EspectaculoFecha"), 0);
               Z4LugarId = (short)(context.localUtil.CToN( cgiGet( "Z4LugarId"), ",", "."));
               Z7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z7TipoEspectaculoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_83 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_83"), ",", "."));
               N4LugarId = (short)(context.localUtil.CToN( cgiGet( "N4LugarId"), ",", "."));
               N7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "N7TipoEspectaculoId"), ",", "."));
               AV7EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vESPECTACULOID"), ",", "."));
               AV11Insert_LugarId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_LUGARID"), ",", "."));
               AV12Insert_TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_TIPOESPECTACULOID"), ",", "."));
               A40000EspectaculoImagen_GXI = cgiGet( "ESPECTACULOIMAGEN_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
               AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
               if ( context.localUtil.VCDate( cgiGet( edtEspectaculoFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Espectaculo Fecha"}), 1, "ESPECTACULOFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16EspectaculoFecha = DateTime.MinValue;
                  AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               }
               else
               {
                  A16EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
                  AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               }
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
               AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LUGARID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4LugarId = 0;
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               }
               else
               {
                  A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               }
               A5LugarName = cgiGet( edtLugarName_Internalname);
               AssignAttri("", false, "A5LugarName", A5LugarName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7TipoEspectaculoId = 0;
                  AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
               }
               else
               {
                  A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."));
                  AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
               }
               A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
               AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A26EspectaculoImagen = cgiGet( imgEspectaculoImagen_Internalname);
               AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgEspectaculoImagen_Internalname, ref  A26EspectaculoImagen, ref  A40000EspectaculoImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EspectaculoId != Z1EspectaculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("espectaculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
                     sMode1 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode1;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound1 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_010( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESPECTACULOID");
                        AnyError = 1;
                        GX_FocusControl = edtEspectaculoId_Internalname;
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
                           E11012 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12012 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll011( ) ;
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
            DisableAttributes011( ) ;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode1 = Gx_mode;
            CONFIRM_0113( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode1;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0113( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0113( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               GetKey0113( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0113( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0113( ) ;
                        CloseExtendedTableCursors0113( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtLugarSectorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( nRcdDeleted_13 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0113( ) ;
                        Load0113( ) ;
                        BeforeValidate0113( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0113( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0113( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0113( ) ;
                              CloseExtendedTableCursors0113( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtLugarSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidadAsientos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorEstadoSector_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41LugarSectorEstadoSector), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z40LugarSectorCantidadAsientos_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40LugarSectorCantidadAsientos), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41LugarSectorEstadoSector), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ",", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption010( )
      {
      }

      protected void E11012( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_LugarId = 0;
         AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
         AV12Insert_TipoEspectaculoId = 0;
         AssignAttri("", false, "AV12Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "LugarId") == 0 )
               {
                  AV11Insert_LugarId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TipoEspectaculoId") == 0 )
               {
                  AV12Insert_TipoEspectaculoId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
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

      protected void E12012( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwespectaculo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2EspectaculoName = T00018_A2EspectaculoName[0];
               Z16EspectaculoFecha = T00018_A16EspectaculoFecha[0];
               Z4LugarId = T00018_A4LugarId[0];
               Z7TipoEspectaculoId = T00018_A7TipoEspectaculoId[0];
            }
            else
            {
               Z2EspectaculoName = A2EspectaculoName;
               Z16EspectaculoFecha = A16EspectaculoFecha;
               Z4LugarId = A4LugarId;
               Z7TipoEspectaculoId = A7TipoEspectaculoId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z26EspectaculoImagen = A26EspectaculoImagen;
            Z40000EspectaculoImagen_GXI = A40000EspectaculoImagen_GXI;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LUGARID"+"'), id:'"+"LUGARID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOESPECTACULOID"+"'), id:'"+"TIPOESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EspectaculoId) )
         {
            A1EspectaculoId = AV7EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            edtLugarId_Enabled = 0;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         else
         {
            edtLugarId_Enabled = 1;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TipoEspectaculoId) )
         {
            edtTipoEspectaculoId_Enabled = 0;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoEspectaculoId_Enabled = 1;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TipoEspectaculoId) )
         {
            A7TipoEspectaculoId = AV12Insert_TipoEspectaculoId;
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            A4LugarId = AV11Insert_LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000110 */
            pr_default.execute(7, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000110_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(7);
            /* Using cursor T00019 */
            pr_default.execute(6, new Object[] {A4LugarId});
            A5LugarName = T00019_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A3PaisId = T00019_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(6);
            /* Using cursor T000111 */
            pr_default.execute(8, new Object[] {A3PaisId});
            A6PaisName = T000111_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(8);
         }
      }

      protected void Load011( )
      {
         /* Using cursor T000112 */
         pr_default.execute(9, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A2EspectaculoName = T000112_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000112_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A6PaisName = T000112_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A5LugarName = T000112_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A8TipoEspectaculoName = T000112_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A40000EspectaculoImagen_GXI = T000112_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            A4LugarId = T000112_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A7TipoEspectaculoId = T000112_A7TipoEspectaculoId[0];
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            A3PaisId = T000112_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A26EspectaculoImagen = T000112_A26EspectaculoImagen[0];
            AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            ZM011( -13) ;
         }
         pr_default.close(9);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! ( (DateTime.MinValue==A16EspectaculoFecha) || ( DateTimeUtil.ResetTime ( A16EspectaculoFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Espectaculo Fecha fuera de rango", "OutOfRange", 1, "ESPECTACULOFECHA");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00019 */
         pr_default.execute(6, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5LugarName = T00019_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A3PaisId = T00019_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         pr_default.close(6);
         /* Using cursor T000111 */
         pr_default.execute(8, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000111_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(8);
         /* Using cursor T000110 */
         pr_default.execute(7, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8TipoEspectaculoName = T000110_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors011( )
      {
         pr_default.close(6);
         pr_default.close(8);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A4LugarId )
      {
         /* Using cursor T000113 */
         pr_default.execute(10, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5LugarName = T000113_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A3PaisId = T000113_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5LugarName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_16( short A3PaisId )
      {
         /* Using cursor T000114 */
         pr_default.execute(11, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000114_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_15( short A7TipoEspectaculoId )
      {
         /* Using cursor T000115 */
         pr_default.execute(12, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8TipoEspectaculoName = T000115_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8TipoEspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey011( )
      {
         /* Using cursor T000116 */
         pr_default.execute(13, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00018 */
         pr_default.execute(5, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM011( 13) ;
            RcdFound1 = 1;
            A1EspectaculoId = T00018_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A2EspectaculoName = T00018_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T00018_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A40000EspectaculoImagen_GXI = T00018_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            A4LugarId = T00018_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A7TipoEspectaculoId = T00018_A7TipoEspectaculoId[0];
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            A26EspectaculoImagen = T00018_A26EspectaculoImagen[0];
            AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            Z1EspectaculoId = A1EspectaculoId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode1;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound1 = 0;
         /* Using cursor T000117 */
         pr_default.execute(14, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000117_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000117_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T000117_A1EspectaculoId[0];
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound1 = 0;
         /* Using cursor T000118 */
         pr_default.execute(15, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000118_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000118_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T000118_A1EspectaculoId[0];
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               RcdFound1 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert011( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  A1EspectaculoId = Z1EspectaculoId;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update011( ) ;
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert011( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESPECTACULOID");
                     AnyError = 1;
                     GX_FocusControl = edtEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspectaculoName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert011( ) ;
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
         if ( A1EspectaculoId != Z1EspectaculoId )
         {
            A1EspectaculoId = Z1EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00017 */
            pr_default.execute(4, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z2EspectaculoName, T00017_A2EspectaculoName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z16EspectaculoFecha ) != DateTimeUtil.ResetTime ( T00017_A16EspectaculoFecha[0] ) ) || ( Z4LugarId != T00017_A4LugarId[0] ) || ( Z7TipoEspectaculoId != T00017_A7TipoEspectaculoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z2EspectaculoName, T00017_A2EspectaculoName[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoName");
                  GXUtil.WriteLogRaw("Old: ",Z2EspectaculoName);
                  GXUtil.WriteLogRaw("Current: ",T00017_A2EspectaculoName[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z16EspectaculoFecha ) != DateTimeUtil.ResetTime ( T00017_A16EspectaculoFecha[0] ) )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z16EspectaculoFecha);
                  GXUtil.WriteLogRaw("Current: ",T00017_A16EspectaculoFecha[0]);
               }
               if ( Z4LugarId != T00017_A4LugarId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarId");
                  GXUtil.WriteLogRaw("Old: ",Z4LugarId);
                  GXUtil.WriteLogRaw("Current: ",T00017_A4LugarId[0]);
               }
               if ( Z7TipoEspectaculoId != T00017_A7TipoEspectaculoId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"TipoEspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z7TipoEspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00017_A7TipoEspectaculoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000119 */
                     pr_default.execute(16, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A4LugarId, A7TipoEspectaculoId});
                     A1EspectaculoId = T000119_A1EspectaculoId[0];
                     AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption010( ) ;
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
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000120 */
                     pr_default.execute(17, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A4LugarId, A7TipoEspectaculoId, A1EspectaculoId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel011( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000121 */
            pr_default.execute(18, new Object[] {A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A1EspectaculoId});
            pr_default.close(18);
            dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
         }
      }

      protected void delete( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0113( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0113( ) ;
                     Delete0113( ) ;
                     ScanNext0113( ) ;
                  }
                  ScanEnd0113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000122 */
                     pr_default.execute(19, new Object[] {A1EspectaculoId});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
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
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel011( ) ;
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000123 */
            pr_default.execute(20, new Object[] {A4LugarId});
            A5LugarName = T000123_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A3PaisId = T000123_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(20);
            /* Using cursor T000124 */
            pr_default.execute(21, new Object[] {A3PaisId});
            A6PaisName = T000124_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(21);
            /* Using cursor T000125 */
            pr_default.execute(22, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000125_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000126 */
            pr_default.execute(23, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Funcion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void ProcessNestedLevel0113( )
      {
         nGXsfl_83_idx = 0;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            ReadRow0113( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal0113( ) ;
               GetKey0113( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0113( ) ;
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( ( nRcdDeleted_13 != 0 ) && ( nRcdExists_13 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0113( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0113( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtLugarSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidadAsientos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorEstadoSector_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41LugarSectorEstadoSector), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z40LugarSectorCantidadAsientos_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40LugarSectorCantidadAsientos), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41LugarSectorEstadoSector), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_83_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ",", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0113( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         nRcdDeleted_13 = 0;
      }

      protected void ProcessLevel011( )
      {
         /* Save parent mode. */
         sMode1 = Gx_mode;
         ProcessNestedLevel0113( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode1;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(21);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("espectaculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues010( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(21);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("espectaculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart011( )
      {
         /* Scan By routine */
         /* Using cursor T000127 */
         pr_default.execute(24);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = T000127_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound1 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound1 = 1;
            A1EspectaculoId = T000127_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
      }

      protected void ScanEnd011( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoName_Enabled = 0;
         AssignProp("", false, edtEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoName_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         edtTipoEspectaculoName_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoName_Enabled), 5, 0), true);
         imgEspectaculoImagen_Enabled = 0;
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgEspectaculoImagen_Enabled), 5, 0), true);
      }

      protected void ZM0113( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z40LugarSectorCantidadAsientos = T00013_A40LugarSectorCantidadAsientos[0];
               Z41LugarSectorEstadoSector = T00013_A41LugarSectorEstadoSector[0];
            }
            else
            {
               Z40LugarSectorCantidadAsientos = A40LugarSectorCantidadAsientos;
               Z41LugarSectorEstadoSector = A41LugarSectorEstadoSector;
            }
         }
         if ( GX_JID == -17 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z40LugarSectorCantidadAsientos = A40LugarSectorCantidadAsientos;
            Z41LugarSectorEstadoSector = A41LugarSectorEstadoSector;
            Z27LugarSectorId = A27LugarSectorId;
            Z28LugarSectorName = A28LugarSectorName;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
         }
      }

      protected void standaloneNotModal0113( )
      {
      }

      protected void standaloneModal0113( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtLugarSectorId_Enabled = 0;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
         else
         {
            edtLugarSectorId_Enabled = 1;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         }
      }

      protected void Load0113( )
      {
         /* Using cursor T000129 */
         pr_default.execute(25, new Object[] {A4LugarId, A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound13 = 1;
            A28LugarSectorName = T000129_A28LugarSectorName[0];
            A40LugarSectorCantidadAsientos = T000129_A40LugarSectorCantidadAsientos[0];
            A41LugarSectorEstadoSector = T000129_A41LugarSectorEstadoSector[0];
            A30LugarSectorPrecio = T000129_A30LugarSectorPrecio[0];
            A37LugarSectorVendidas = T000129_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000129_n37LugarSectorVendidas[0];
            ZM0113( -17) ;
         }
         pr_default.close(25);
         OnLoadActions0113( ) ;
      }

      protected void OnLoadActions0113( )
      {
         A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
      }

      protected void CheckExtendedTable0113( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal0113( ) ;
         /* Using cursor T00014 */
         pr_default.execute(2, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T00014_A28LugarSectorName[0];
         A30LugarSectorPrecio = T00014_A30LugarSectorPrecio[0];
         pr_default.close(2);
         /* Using cursor T00016 */
         pr_default.execute(3, new Object[] {A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A37LugarSectorVendidas = T00016_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T00016_n37LugarSectorVendidas[0];
         }
         else
         {
            nIsDirty_13 = 1;
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(3);
         nIsDirty_13 = 1;
         A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
      }

      protected void CloseExtendedTableCursors0113( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0113( )
      {
      }

      protected void gxLoad_18( short A4LugarId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000130 */
         pr_default.execute(26, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000130_A28LugarSectorName[0];
         A30LugarSectorPrecio = T000130_A30LugarSectorPrecio[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28LugarSectorName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_19( short A27LugarSectorId ,
                                short A1EspectaculoId )
      {
         /* Using cursor T000132 */
         pr_default.execute(27, new Object[] {A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A37LugarSectorVendidas = T000132_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000132_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void GetKey0113( )
      {
         /* Using cursor T000133 */
         pr_default.execute(28, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(28);
      }

      protected void getByPrimaryKey0113( )
      {
         /* Using cursor T00013 */
         pr_default.execute(1, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0113( 17) ;
            RcdFound13 = 1;
            InitializeNonKey0113( ) ;
            A40LugarSectorCantidadAsientos = T00013_A40LugarSectorCantidadAsientos[0];
            A41LugarSectorEstadoSector = T00013_A41LugarSectorEstadoSector[0];
            A27LugarSectorId = T00013_A27LugarSectorId[0];
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0113( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0113( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0113( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0113( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0113( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00012 */
            pr_default.execute(0, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoLugarSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z40LugarSectorCantidadAsientos != T00012_A40LugarSectorCantidadAsientos[0] ) || ( Z41LugarSectorEstadoSector != T00012_A41LugarSectorEstadoSector[0] ) )
            {
               if ( Z40LugarSectorCantidadAsientos != T00012_A40LugarSectorCantidadAsientos[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarSectorCantidadAsientos");
                  GXUtil.WriteLogRaw("Old: ",Z40LugarSectorCantidadAsientos);
                  GXUtil.WriteLogRaw("Current: ",T00012_A40LugarSectorCantidadAsientos[0]);
               }
               if ( Z41LugarSectorEstadoSector != T00012_A41LugarSectorEstadoSector[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarSectorEstadoSector");
                  GXUtil.WriteLogRaw("Old: ",Z41LugarSectorEstadoSector);
                  GXUtil.WriteLogRaw("Current: ",T00012_A41LugarSectorEstadoSector[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EspectaculoLugarSector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0113( )
      {
         BeforeValidate0113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0113( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0113( 0) ;
            CheckOptimisticConcurrency0113( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0113( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0113( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000134 */
                     pr_default.execute(29, new Object[] {A1EspectaculoId, A40LugarSectorCantidadAsientos, A41LugarSectorEstadoSector, A27LugarSectorId});
                     pr_default.close(29);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                     if ( (pr_default.getStatus(29) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0113( ) ;
            }
            EndLevel0113( ) ;
         }
         CloseExtendedTableCursors0113( ) ;
      }

      protected void Update0113( )
      {
         BeforeValidate0113( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0113( ) ;
         }
         if ( ( nIsMod_13 != 0 ) || ( nIsDirty_13 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0113( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0113( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0113( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000135 */
                        pr_default.execute(30, new Object[] {A40LugarSectorCantidadAsientos, A41LugarSectorEstadoSector, A1EspectaculoId, A27LugarSectorId});
                        pr_default.close(30);
                        dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                        if ( (pr_default.getStatus(30) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoLugarSector"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0113( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0113( ) ;
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
               EndLevel0113( ) ;
            }
         }
         CloseExtendedTableCursors0113( ) ;
      }

      protected void DeferredUpdate0113( )
      {
      }

      protected void Delete0113( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0113( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0113( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0113( ) ;
            AfterConfirm0113( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0113( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000136 */
                  pr_default.execute(31, new Object[] {A1EspectaculoId, A27LugarSectorId});
                  pr_default.close(31);
                  dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0113( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0113( )
      {
         standaloneModal0113( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000137 */
            pr_default.execute(32, new Object[] {A4LugarId, A27LugarSectorId});
            A28LugarSectorName = T000137_A28LugarSectorName[0];
            A30LugarSectorPrecio = T000137_A30LugarSectorPrecio[0];
            pr_default.close(32);
            /* Using cursor T000139 */
            pr_default.execute(33, new Object[] {A27LugarSectorId, A1EspectaculoId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               A37LugarSectorVendidas = T000139_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = T000139_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
            }
            pr_default.close(33);
            A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
         }
      }

      protected void EndLevel0113( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0113( )
      {
         /* Scan By routine */
         /* Using cursor T000140 */
         pr_default.execute(34, new Object[] {A1EspectaculoId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound13 = 1;
            A27LugarSectorId = T000140_A27LugarSectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0113( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound13 = 1;
            A27LugarSectorId = T000140_A27LugarSectorId[0];
         }
      }

      protected void ScanEnd0113( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm0113( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0113( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0113( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0113( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0113( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0113( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0113( )
      {
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorName_Enabled = 0;
         AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorCantidadAsientos_Enabled = 0;
         AssignProp("", false, edtLugarSectorCantidadAsientos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorEstadoSector_Enabled = 0;
         AssignProp("", false, edtLugarSectorEstadoSector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorPrecio_Enabled = 0;
         AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorVendidas_Enabled = 0;
         AssignProp("", false, edtLugarSectorVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0), !bGXsfl_83_Refreshing);
         edtLugarSectorDisponibles_Enabled = 0;
         AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void send_integrity_lvl_hashes0113( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void SubsflControlProps_8313( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_83_idx;
         imgprompt_27_Internalname = "PROMPT_27_"+sGXsfl_83_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_83_idx;
         edtLugarSectorCantidadAsientos_Internalname = "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx;
         edtLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_83_idx;
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx;
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx;
      }

      protected void SubsflControlProps_fel_8313( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_83_fel_idx;
         imgprompt_27_Internalname = "PROMPT_27_"+sGXsfl_83_fel_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_83_fel_idx;
         edtLugarSectorCantidadAsientos_Internalname = "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_fel_idx;
         edtLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_fel_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_83_fel_idx;
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS_"+sGXsfl_83_fel_idx;
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES_"+sGXsfl_83_fel_idx;
      }

      protected void AddRow0113( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8313( ) ;
         SendRow0113( ) ;
      }

      protected void SendRow0113( )
      {
         Gridespectaculo_lugarsectorRow = GXWebRow.GetNew(context);
         if ( subGridespectaculo_lugarsector_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
            }
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 0;
            subGridespectaculo_lugarsector_Backcolor = subGridespectaculo_lugarsector_Allbackcolor;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Uniform";
            }
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
            }
            subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 1;
            if ( ((int)((nGXsfl_83_idx) % (2))) == 0 )
            {
               subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
               {
                  subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Even";
               }
            }
            else
            {
               subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
               {
                  subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
               }
            }
         }
         imgprompt_27_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00b1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LUGARID"+"'), id:'"+"LUGARID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"LUGARSECTORID_"+sGXsfl_83_idx+"'), id:'"+"LUGARSECTORID_"+sGXsfl_83_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_13_"+sGXsfl_83_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridespectaculo_lugarsectorRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_27_Internalname,(string)sImgUrl,(string)imgprompt_27_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_27_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorName_Internalname,(string)A28LugarSectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 86,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorCantidadAsientos_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorCantidadAsientos_Enabled!=0) ? context.localUtil.Format( (decimal)(A40LugarSectorCantidadAsientos), "ZZZ9") : context.localUtil.Format( (decimal)(A40LugarSectorCantidadAsientos), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorCantidadAsientos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorCantidadAsientos_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_83_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_83_idx + "',83)\"";
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorEstadoSector_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A41LugarSectorEstadoSector), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorEstadoSector_Enabled!=0) ? context.localUtil.Format( (decimal)(A41LugarSectorEstadoSector), "ZZZ9") : context.localUtil.Format( (decimal)(A41LugarSectorEstadoSector), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,87);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorEstadoSector_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorEstadoSector_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorVendidas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorVendidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A37LugarSectorVendidas), "ZZZ9") : context.localUtil.Format( (decimal)(A37LugarSectorVendidas), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorVendidas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorVendidas_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorDisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9") : context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorDisponibles_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorDisponibles_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)83,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridespectaculo_lugarsectorRow);
         send_integrity_lvl_hashes0113( ) ;
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", "")));
         GXCCtl = "Z40LugarSectorCantidadAsientos_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40LugarSectorCantidadAsientos), 4, 0, ",", "")));
         GXCCtl = "Z41LugarSectorEstadoSector_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41LugarSectorEstadoSector), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_13_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ",", "")));
         GXCCtl = "nIsMod_13_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_83_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vESPECTACULOID_" + sGXsfl_83_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORID_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORNAME_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORPRECIO_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_27_"+sGXsfl_83_idx+"Link", StringUtil.RTrim( imgprompt_27_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridespectaculo_lugarsectorContainer.AddRow(Gridespectaculo_lugarsectorRow);
      }

      protected void ReadRow0113( )
      {
         nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8313( ) ;
         edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorCantidadAsientos_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDADASIENTOS_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorEstadoSector_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORESTADOSECTOR_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorVendidas_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         edtLugarSectorDisponibles_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORDISPONIBLES_"+sGXsfl_83_idx+"Enabled"), ",", "."));
         imgprompt_4_Link = cgiGet( "PROMPT_27_"+sGXsfl_83_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            wbErr = true;
            A27LugarSectorId = 0;
         }
         else
         {
            A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
         }
         A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorCantidadAsientos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorCantidadAsientos_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORCANTIDADASIENTOS_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorCantidadAsientos_Internalname;
            wbErr = true;
            A40LugarSectorCantidadAsientos = 0;
         }
         else
         {
            A40LugarSectorCantidadAsientos = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorCantidadAsientos_Internalname), ",", "."));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorEstadoSector_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorEstadoSector_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORESTADOSECTOR_" + sGXsfl_83_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorEstadoSector_Internalname;
            wbErr = true;
            A41LugarSectorEstadoSector = 0;
         }
         else
         {
            A41LugarSectorEstadoSector = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorEstadoSector_Internalname), ",", "."));
         }
         A30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", "."));
         A37LugarSectorVendidas = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorVendidas_Internalname), ",", "."));
         n37LugarSectorVendidas = false;
         A38LugarSectorDisponibles = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorDisponibles_Internalname), ",", "."));
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_83_idx;
         Z27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z40LugarSectorCantidadAsientos_" + sGXsfl_83_idx;
         Z40LugarSectorCantidadAsientos = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z41LugarSectorEstadoSector_" + sGXsfl_83_idx;
         Z41LugarSectorEstadoSector = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_83_idx;
         nRcdDeleted_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_13_" + sGXsfl_83_idx;
         nRcdExists_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_13_" + sGXsfl_83_idx;
         nIsMod_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtLugarSectorId_Enabled = edtLugarSectorId_Enabled;
      }

      protected void ConfirmValues010( )
      {
         nGXsfl_83_idx = 0;
         sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
         SubsflControlProps_8313( ) ;
         while ( nGXsfl_83_idx < nRC_GXsfl_83 )
         {
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8313( ) ;
            ChangePostValue( "Z27LugarSectorId_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z27LugarSectorId_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z40LugarSectorCantidadAsientos_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z40LugarSectorCantidadAsientos_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z40LugarSectorCantidadAsientos_"+sGXsfl_83_idx) ;
            ChangePostValue( "Z41LugarSectorEstadoSector_"+sGXsfl_83_idx, cgiGet( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_83_idx)) ;
            DeletePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_83_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?20228913592278", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("espectaculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2EspectaculoName", Z2EspectaculoName);
         GxWebStd.gx_hidden_field( context, "Z16EspectaculoFecha", context.localUtil.DToC( Z16EspectaculoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_83", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_83_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOIMAGEN_GXI", A40000EspectaculoImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "ESPECTACULOIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A26EspectaculoImagen);
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
         return formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Espectaculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Espectaculo" ;
      }

      protected void InitializeNonKey011( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A7TipoEspectaculoId = 0;
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         A2EspectaculoName = "";
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A8TipoEspectaculoName = "";
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         A26EspectaculoImagen = "";
         AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
         A40000EspectaculoImagen_GXI = "";
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z4LugarId = 0;
         Z7TipoEspectaculoId = 0;
      }

      protected void InitAll011( )
      {
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0113( )
      {
         A38LugarSectorDisponibles = 0;
         A28LugarSectorName = "";
         A40LugarSectorCantidadAsientos = 0;
         A41LugarSectorEstadoSector = 0;
         A30LugarSectorPrecio = 0;
         A37LugarSectorVendidas = 0;
         n37LugarSectorVendidas = false;
         Z40LugarSectorCantidadAsientos = 0;
         Z41LugarSectorEstadoSector = 0;
      }

      protected void InitAll0113( )
      {
         A27LugarSectorId = 0;
         InitializeNonKey0113( ) ;
      }

      protected void StandaloneModalInsert0113( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228913592284", true, true);
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
         context.AddJavascriptSource("espectaculo.js", "?20228913592284", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties13( )
      {
         edtLugarSectorId_Enabled = defedtLugarSectorId_Enabled;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_83_Refreshing);
      }

      protected void StartGridControl83( )
      {
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("GridName", "Gridespectaculo_lugarsector");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Header", subGridespectaculo_lugarsector_Header);
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Class", "Grid");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Backcolorstyle), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("CmpContext", "");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("InMasterPage", "false");
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", A28LugarSectorName);
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidadAsientos_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41LugarSectorEstadoSector), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorEstadoSector_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Selectedindex), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowselection), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Selectioncolor), 9, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowhovering), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Hoveringcolor), 9, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowcollapsing), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Collapsed), 1, 0, ".", "")));
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
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoName_Internalname = "ESPECTACULONAME";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtPaisId_Internalname = "PAISID";
         edtPaisName_Internalname = "PAISNAME";
         edtLugarId_Internalname = "LUGARID";
         edtLugarName_Internalname = "LUGARNAME";
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
         edtTipoEspectaculoName_Internalname = "TIPOESPECTACULONAME";
         lblTitlelugarsector_Internalname = "TITLELUGARSECTOR";
         edtLugarSectorId_Internalname = "LUGARSECTORID";
         edtLugarSectorName_Internalname = "LUGARSECTORNAME";
         edtLugarSectorCantidadAsientos_Internalname = "LUGARSECTORCANTIDADASIENTOS";
         edtLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR";
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO";
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS";
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES";
         divLugarsectortable_Internalname = "LUGARSECTORTABLE";
         imgEspectaculoImagen_Internalname = "ESPECTACULOIMAGEN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_7_Internalname = "PROMPT_7";
         imgprompt_27_Internalname = "PROMPT_27";
         subGridespectaculo_lugarsector_Internalname = "GRIDESPECTACULO_LUGARSECTOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridespectaculo_lugarsector_Allowcollapsing = 0;
         subGridespectaculo_lugarsector_Allowselection = 0;
         subGridespectaculo_lugarsector_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Espectaculo";
         edtLugarSectorDisponibles_Jsonclick = "";
         edtLugarSectorVendidas_Jsonclick = "";
         edtLugarSectorPrecio_Jsonclick = "";
         edtLugarSectorEstadoSector_Jsonclick = "";
         edtLugarSectorCantidadAsientos_Jsonclick = "";
         edtLugarSectorName_Jsonclick = "";
         imgprompt_27_Visible = 1;
         imgprompt_27_Link = "";
         imgprompt_4_Visible = 1;
         edtLugarSectorId_Jsonclick = "";
         subGridespectaculo_lugarsector_Class = "Grid";
         subGridespectaculo_lugarsector_Backcolorstyle = 0;
         edtLugarSectorDisponibles_Enabled = 0;
         edtLugarSectorVendidas_Enabled = 0;
         edtLugarSectorPrecio_Enabled = 0;
         edtLugarSectorEstadoSector_Enabled = 1;
         edtLugarSectorCantidadAsientos_Enabled = 1;
         edtLugarSectorName_Enabled = 0;
         edtLugarSectorId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgEspectaculoImagen_Enabled = 1;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Enabled = 0;
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         edtTipoEspectaculoId_Jsonclick = "";
         edtTipoEspectaculoId_Enabled = 1;
         edtLugarName_Jsonclick = "";
         edtLugarName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtLugarId_Jsonclick = "";
         edtLugarId_Enabled = 1;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 1;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 1;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
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

      protected void gxnrGridespectaculo_lugarsector_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8313( ) ;
         while ( nGXsfl_83_idx <= nRC_GXsfl_83 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0113( ) ;
            standaloneModal0113( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0113( ) ;
            nGXsfl_83_idx = (int)(nGXsfl_83_idx+1);
            sGXsfl_83_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_83_idx), 4, 0), 4, "0");
            SubsflControlProps_8313( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridespectaculo_lugarsectorContainer)) ;
         /* End function gxnrGridespectaculo_lugarsector_newrow */
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

      public void Valid_Paisid( )
      {
         /* Using cursor T000124 */
         pr_default.execute(21, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000124_A6PaisName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public void Valid_Lugarid( )
      {
         /* Using cursor T000123 */
         pr_default.execute(20, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
         }
         A5LugarName = T000123_A5LugarName[0];
         A3PaisId = T000123_A3PaisId[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5LugarName", A5LugarName);
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
      }

      public void Valid_Tipoespectaculoid( )
      {
         /* Using cursor T000125 */
         pr_default.execute(22, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
         }
         A8TipoEspectaculoName = T000125_A8TipoEspectaculoName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
      }

      public void Valid_Lugarsectorid( )
      {
         n37LugarSectorVendidas = false;
         /* Using cursor T000137 */
         pr_default.execute(32, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         A28LugarSectorName = T000137_A28LugarSectorName[0];
         A30LugarSectorPrecio = T000137_A30LugarSectorPrecio[0];
         pr_default.close(32);
         /* Using cursor T000139 */
         pr_default.execute(33, new Object[] {A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            A37LugarSectorVendidas = T000139_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000139_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12012',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_LUGARID","{handler:'Valid_Lugarid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_LUGARID",",oparms:[{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_TIPOESPECTACULOID","{handler:'Valid_Tipoespectaculoid',iparms:[{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]");
         setEventMetadata("VALID_TIPOESPECTACULOID",",oparms:[{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A27LugarSectorId',fld:'LUGARSECTORID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_LUGARSECTORCANTIDADASIENTOS","{handler:'Valid_Lugarsectorcantidadasientos',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORCANTIDADASIENTOS",",oparms:[]}");
         setEventMetadata("VALID_LUGARSECTORVENDIDAS","{handler:'Valid_Lugarsectorvendidas',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORVENDIDAS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Lugarsectordisponibles',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
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
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A6PaisName = "";
         sImgUrl = "";
         A5LugarName = "";
         A8TipoEspectaculoName = "";
         lblTitlelugarsector_Jsonclick = "";
         A26EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridespectaculo_lugarsectorContainer = new GXWebGrid( context);
         sMode13 = "";
         sStyleString = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode1 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A28LugarSectorName = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z26EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         Z5LugarName = "";
         Z6PaisName = "";
         Z8TipoEspectaculoName = "";
         T000110_A8TipoEspectaculoName = new string[] {""} ;
         T00019_A5LugarName = new string[] {""} ;
         T00019_A3PaisId = new short[1] ;
         T000111_A6PaisName = new string[] {""} ;
         T000112_A1EspectaculoId = new short[1] ;
         T000112_A2EspectaculoName = new string[] {""} ;
         T000112_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000112_A6PaisName = new string[] {""} ;
         T000112_A5LugarName = new string[] {""} ;
         T000112_A8TipoEspectaculoName = new string[] {""} ;
         T000112_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T000112_A4LugarId = new short[1] ;
         T000112_A7TipoEspectaculoId = new short[1] ;
         T000112_A3PaisId = new short[1] ;
         T000112_A26EspectaculoImagen = new string[] {""} ;
         T000113_A5LugarName = new string[] {""} ;
         T000113_A3PaisId = new short[1] ;
         T000114_A6PaisName = new string[] {""} ;
         T000115_A8TipoEspectaculoName = new string[] {""} ;
         T000116_A1EspectaculoId = new short[1] ;
         T00018_A1EspectaculoId = new short[1] ;
         T00018_A2EspectaculoName = new string[] {""} ;
         T00018_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00018_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T00018_A4LugarId = new short[1] ;
         T00018_A7TipoEspectaculoId = new short[1] ;
         T00018_A26EspectaculoImagen = new string[] {""} ;
         T000117_A1EspectaculoId = new short[1] ;
         T000118_A1EspectaculoId = new short[1] ;
         T00017_A1EspectaculoId = new short[1] ;
         T00017_A2EspectaculoName = new string[] {""} ;
         T00017_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00017_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T00017_A4LugarId = new short[1] ;
         T00017_A7TipoEspectaculoId = new short[1] ;
         T00017_A26EspectaculoImagen = new string[] {""} ;
         T000119_A1EspectaculoId = new short[1] ;
         T000123_A5LugarName = new string[] {""} ;
         T000123_A3PaisId = new short[1] ;
         T000124_A6PaisName = new string[] {""} ;
         T000125_A8TipoEspectaculoName = new string[] {""} ;
         T000126_A15FuncionId = new short[1] ;
         T000127_A1EspectaculoId = new short[1] ;
         Z28LugarSectorName = "";
         T000129_A4LugarId = new short[1] ;
         T000129_A1EspectaculoId = new short[1] ;
         T000129_A28LugarSectorName = new string[] {""} ;
         T000129_A40LugarSectorCantidadAsientos = new short[1] ;
         T000129_A41LugarSectorEstadoSector = new short[1] ;
         T000129_A30LugarSectorPrecio = new short[1] ;
         T000129_A27LugarSectorId = new short[1] ;
         T000129_A37LugarSectorVendidas = new short[1] ;
         T000129_n37LugarSectorVendidas = new bool[] {false} ;
         T00014_A28LugarSectorName = new string[] {""} ;
         T00014_A30LugarSectorPrecio = new short[1] ;
         T00016_A37LugarSectorVendidas = new short[1] ;
         T00016_n37LugarSectorVendidas = new bool[] {false} ;
         T000130_A28LugarSectorName = new string[] {""} ;
         T000130_A30LugarSectorPrecio = new short[1] ;
         T000132_A37LugarSectorVendidas = new short[1] ;
         T000132_n37LugarSectorVendidas = new bool[] {false} ;
         T000133_A1EspectaculoId = new short[1] ;
         T000133_A27LugarSectorId = new short[1] ;
         T00013_A1EspectaculoId = new short[1] ;
         T00013_A40LugarSectorCantidadAsientos = new short[1] ;
         T00013_A41LugarSectorEstadoSector = new short[1] ;
         T00013_A27LugarSectorId = new short[1] ;
         T00012_A1EspectaculoId = new short[1] ;
         T00012_A40LugarSectorCantidadAsientos = new short[1] ;
         T00012_A41LugarSectorEstadoSector = new short[1] ;
         T00012_A27LugarSectorId = new short[1] ;
         T000137_A28LugarSectorName = new string[] {""} ;
         T000137_A30LugarSectorPrecio = new short[1] ;
         T000139_A37LugarSectorVendidas = new short[1] ;
         T000139_n37LugarSectorVendidas = new bool[] {false} ;
         T000140_A1EspectaculoId = new short[1] ;
         T000140_A27LugarSectorId = new short[1] ;
         Gridespectaculo_lugarsectorRow = new GXWebRow();
         subGridespectaculo_lugarsector_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridespectaculo_lugarsectorColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo__default(),
            new Object[][] {
                new Object[] {
               T00012_A1EspectaculoId, T00012_A40LugarSectorCantidadAsientos, T00012_A41LugarSectorEstadoSector, T00012_A27LugarSectorId
               }
               , new Object[] {
               T00013_A1EspectaculoId, T00013_A40LugarSectorCantidadAsientos, T00013_A41LugarSectorEstadoSector, T00013_A27LugarSectorId
               }
               , new Object[] {
               T00014_A28LugarSectorName, T00014_A30LugarSectorPrecio
               }
               , new Object[] {
               T00016_A37LugarSectorVendidas, T00016_n37LugarSectorVendidas
               }
               , new Object[] {
               T00017_A1EspectaculoId, T00017_A2EspectaculoName, T00017_A16EspectaculoFecha, T00017_A40000EspectaculoImagen_GXI, T00017_A4LugarId, T00017_A7TipoEspectaculoId, T00017_A26EspectaculoImagen
               }
               , new Object[] {
               T00018_A1EspectaculoId, T00018_A2EspectaculoName, T00018_A16EspectaculoFecha, T00018_A40000EspectaculoImagen_GXI, T00018_A4LugarId, T00018_A7TipoEspectaculoId, T00018_A26EspectaculoImagen
               }
               , new Object[] {
               T00019_A5LugarName, T00019_A3PaisId
               }
               , new Object[] {
               T000110_A8TipoEspectaculoName
               }
               , new Object[] {
               T000111_A6PaisName
               }
               , new Object[] {
               T000112_A1EspectaculoId, T000112_A2EspectaculoName, T000112_A16EspectaculoFecha, T000112_A6PaisName, T000112_A5LugarName, T000112_A8TipoEspectaculoName, T000112_A40000EspectaculoImagen_GXI, T000112_A4LugarId, T000112_A7TipoEspectaculoId, T000112_A3PaisId,
               T000112_A26EspectaculoImagen
               }
               , new Object[] {
               T000113_A5LugarName, T000113_A3PaisId
               }
               , new Object[] {
               T000114_A6PaisName
               }
               , new Object[] {
               T000115_A8TipoEspectaculoName
               }
               , new Object[] {
               T000116_A1EspectaculoId
               }
               , new Object[] {
               T000117_A1EspectaculoId
               }
               , new Object[] {
               T000118_A1EspectaculoId
               }
               , new Object[] {
               T000119_A1EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000123_A5LugarName, T000123_A3PaisId
               }
               , new Object[] {
               T000124_A6PaisName
               }
               , new Object[] {
               T000125_A8TipoEspectaculoName
               }
               , new Object[] {
               T000126_A15FuncionId
               }
               , new Object[] {
               T000127_A1EspectaculoId
               }
               , new Object[] {
               T000129_A4LugarId, T000129_A1EspectaculoId, T000129_A28LugarSectorName, T000129_A40LugarSectorCantidadAsientos, T000129_A41LugarSectorEstadoSector, T000129_A30LugarSectorPrecio, T000129_A27LugarSectorId, T000129_A37LugarSectorVendidas, T000129_n37LugarSectorVendidas
               }
               , new Object[] {
               T000130_A28LugarSectorName, T000130_A30LugarSectorPrecio
               }
               , new Object[] {
               T000132_A37LugarSectorVendidas, T000132_n37LugarSectorVendidas
               }
               , new Object[] {
               T000133_A1EspectaculoId, T000133_A27LugarSectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000137_A28LugarSectorName, T000137_A30LugarSectorPrecio
               }
               , new Object[] {
               T000139_A37LugarSectorVendidas, T000139_n37LugarSectorVendidas
               }
               , new Object[] {
               T000140_A1EspectaculoId, T000140_A27LugarSectorId
               }
            }
         );
         AV14Pgmname = "Espectaculo";
      }

      private short nIsMod_13 ;
      private short wcpOAV7EspectaculoId ;
      private short Z1EspectaculoId ;
      private short Z4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short N4LugarId ;
      private short N7TipoEspectaculoId ;
      private short Z27LugarSectorId ;
      private short Z40LugarSectorCantidadAsientos ;
      private short Z41LugarSectorEstadoSector ;
      private short nRcdDeleted_13 ;
      private short nRcdExists_13 ;
      private short GxWebError ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short A7TipoEspectaculoId ;
      private short A27LugarSectorId ;
      private short A1EspectaculoId ;
      private short AV7EspectaculoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount13 ;
      private short RcdFound13 ;
      private short nBlankRcdUsr13 ;
      private short AV11Insert_LugarId ;
      private short AV12Insert_TipoEspectaculoId ;
      private short RcdFound1 ;
      private short A40LugarSectorCantidadAsientos ;
      private short A41LugarSectorEstadoSector ;
      private short A30LugarSectorPrecio ;
      private short A37LugarSectorVendidas ;
      private short A38LugarSectorDisponibles ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short Gx_BScreen ;
      private short nIsDirty_1 ;
      private short Z30LugarSectorPrecio ;
      private short Z37LugarSectorVendidas ;
      private short nIsDirty_13 ;
      private short subGridespectaculo_lugarsector_Backcolorstyle ;
      private short subGridespectaculo_lugarsector_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridespectaculo_lugarsector_Allowselection ;
      private short subGridespectaculo_lugarsector_Allowhovering ;
      private short subGridespectaculo_lugarsector_Allowcollapsing ;
      private short subGridespectaculo_lugarsector_Collapsed ;
      private int nRC_GXsfl_83 ;
      private int nGXsfl_83_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtLugarId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtLugarName_Enabled ;
      private int edtTipoEspectaculoId_Enabled ;
      private int imgprompt_7_Visible ;
      private int edtTipoEspectaculoName_Enabled ;
      private int imgEspectaculoImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtLugarSectorId_Enabled ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorCantidadAsientos_Enabled ;
      private int edtLugarSectorEstadoSector_Enabled ;
      private int edtLugarSectorPrecio_Enabled ;
      private int edtLugarSectorVendidas_Enabled ;
      private int edtLugarSectorDisponibles_Enabled ;
      private int fRowAdded ;
      private int AV15GXV1 ;
      private int subGridespectaculo_lugarsector_Backcolor ;
      private int subGridespectaculo_lugarsector_Allbackcolor ;
      private int imgprompt_27_Visible ;
      private int defedtLugarSectorId_Enabled ;
      private int idxLst ;
      private int subGridespectaculo_lugarsector_Selectedindex ;
      private int subGridespectaculo_lugarsector_Selectioncolor ;
      private int subGridespectaculo_lugarsector_Hoveringcolor ;
      private long GRIDESPECTACULO_LUGARSECTOR_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_83_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEspectaculoName_Internalname ;
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
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtLugarId_Internalname ;
      private string edtLugarId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Jsonclick ;
      private string edtTipoEspectaculoId_Internalname ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string imgprompt_7_Internalname ;
      private string imgprompt_7_Link ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string divLugarsectortable_Internalname ;
      private string lblTitlelugarsector_Internalname ;
      private string lblTitlelugarsector_Jsonclick ;
      private string imgEspectaculoImagen_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode13 ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorCantidadAsientos_Internalname ;
      private string edtLugarSectorEstadoSector_Internalname ;
      private string edtLugarSectorPrecio_Internalname ;
      private string edtLugarSectorVendidas_Internalname ;
      private string edtLugarSectorDisponibles_Internalname ;
      private string sStyleString ;
      private string subGridespectaculo_lugarsector_Internalname ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode1 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_27_Internalname ;
      private string sGXsfl_83_fel_idx="0001" ;
      private string subGridespectaculo_lugarsector_Class ;
      private string subGridespectaculo_lugarsector_Linesclass ;
      private string imgprompt_27_Link ;
      private string ROClassString ;
      private string edtLugarSectorId_Jsonclick ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorCantidadAsientos_Jsonclick ;
      private string edtLugarSectorEstadoSector_Jsonclick ;
      private string edtLugarSectorPrecio_Jsonclick ;
      private string edtLugarSectorVendidas_Jsonclick ;
      private string edtLugarSectorDisponibles_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridespectaculo_lugarsector_Header ;
      private DateTime Z16EspectaculoFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A26EspectaculoImagen_IsBlob ;
      private bool bGXsfl_83_Refreshing=false ;
      private bool returnInSub ;
      private bool n37LugarSectorVendidas ;
      private string Z2EspectaculoName ;
      private string A2EspectaculoName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A8TipoEspectaculoName ;
      private string A40000EspectaculoImagen_GXI ;
      private string A28LugarSectorName ;
      private string Z40000EspectaculoImagen_GXI ;
      private string Z5LugarName ;
      private string Z6PaisName ;
      private string Z8TipoEspectaculoName ;
      private string Z28LugarSectorName ;
      private string A26EspectaculoImagen ;
      private string Z26EspectaculoImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridespectaculo_lugarsectorContainer ;
      private GXWebRow Gridespectaculo_lugarsectorRow ;
      private GXWebColumn Gridespectaculo_lugarsectorColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000110_A8TipoEspectaculoName ;
      private string[] T00019_A5LugarName ;
      private short[] T00019_A3PaisId ;
      private string[] T000111_A6PaisName ;
      private short[] T000112_A1EspectaculoId ;
      private string[] T000112_A2EspectaculoName ;
      private DateTime[] T000112_A16EspectaculoFecha ;
      private string[] T000112_A6PaisName ;
      private string[] T000112_A5LugarName ;
      private string[] T000112_A8TipoEspectaculoName ;
      private string[] T000112_A40000EspectaculoImagen_GXI ;
      private short[] T000112_A4LugarId ;
      private short[] T000112_A7TipoEspectaculoId ;
      private short[] T000112_A3PaisId ;
      private string[] T000112_A26EspectaculoImagen ;
      private string[] T000113_A5LugarName ;
      private short[] T000113_A3PaisId ;
      private string[] T000114_A6PaisName ;
      private string[] T000115_A8TipoEspectaculoName ;
      private short[] T000116_A1EspectaculoId ;
      private short[] T00018_A1EspectaculoId ;
      private string[] T00018_A2EspectaculoName ;
      private DateTime[] T00018_A16EspectaculoFecha ;
      private string[] T00018_A40000EspectaculoImagen_GXI ;
      private short[] T00018_A4LugarId ;
      private short[] T00018_A7TipoEspectaculoId ;
      private string[] T00018_A26EspectaculoImagen ;
      private short[] T000117_A1EspectaculoId ;
      private short[] T000118_A1EspectaculoId ;
      private short[] T00017_A1EspectaculoId ;
      private string[] T00017_A2EspectaculoName ;
      private DateTime[] T00017_A16EspectaculoFecha ;
      private string[] T00017_A40000EspectaculoImagen_GXI ;
      private short[] T00017_A4LugarId ;
      private short[] T00017_A7TipoEspectaculoId ;
      private string[] T00017_A26EspectaculoImagen ;
      private short[] T000119_A1EspectaculoId ;
      private string[] T000123_A5LugarName ;
      private short[] T000123_A3PaisId ;
      private string[] T000124_A6PaisName ;
      private string[] T000125_A8TipoEspectaculoName ;
      private short[] T000126_A15FuncionId ;
      private short[] T000127_A1EspectaculoId ;
      private short[] T000129_A4LugarId ;
      private short[] T000129_A1EspectaculoId ;
      private string[] T000129_A28LugarSectorName ;
      private short[] T000129_A40LugarSectorCantidadAsientos ;
      private short[] T000129_A41LugarSectorEstadoSector ;
      private short[] T000129_A30LugarSectorPrecio ;
      private short[] T000129_A27LugarSectorId ;
      private short[] T000129_A37LugarSectorVendidas ;
      private bool[] T000129_n37LugarSectorVendidas ;
      private string[] T00014_A28LugarSectorName ;
      private short[] T00014_A30LugarSectorPrecio ;
      private short[] T00016_A37LugarSectorVendidas ;
      private bool[] T00016_n37LugarSectorVendidas ;
      private string[] T000130_A28LugarSectorName ;
      private short[] T000130_A30LugarSectorPrecio ;
      private short[] T000132_A37LugarSectorVendidas ;
      private bool[] T000132_n37LugarSectorVendidas ;
      private short[] T000133_A1EspectaculoId ;
      private short[] T000133_A27LugarSectorId ;
      private short[] T00013_A1EspectaculoId ;
      private short[] T00013_A40LugarSectorCantidadAsientos ;
      private short[] T00013_A41LugarSectorEstadoSector ;
      private short[] T00013_A27LugarSectorId ;
      private short[] T00012_A1EspectaculoId ;
      private short[] T00012_A40LugarSectorCantidadAsientos ;
      private short[] T00012_A41LugarSectorEstadoSector ;
      private short[] T00012_A27LugarSectorId ;
      private string[] T000137_A28LugarSectorName ;
      private short[] T000137_A30LugarSectorPrecio ;
      private short[] T000139_A37LugarSectorVendidas ;
      private bool[] T000139_n37LugarSectorVendidas ;
      private short[] T000140_A1EspectaculoId ;
      private short[] T000140_A27LugarSectorId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class espectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new UpdateCursor(def[30])
         ,new UpdateCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000112;
          prmT000112 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00019;
          prmT00019 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000111;
          prmT000111 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000110;
          prmT000110 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000113;
          prmT000113 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000114;
          prmT000114 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000115;
          prmT000115 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000116;
          prmT000116 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00018;
          prmT00018 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000117;
          prmT000117 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000118;
          prmT000118 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00017;
          prmT00017 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000119;
          prmT000119 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000120;
          prmT000120 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000121;
          prmT000121 = new Object[] {
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000122;
          prmT000122 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000126;
          prmT000126 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000127;
          prmT000127 = new Object[] {
          };
          Object[] prmT000129;
          prmT000129 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00014;
          prmT00014 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00016;
          prmT00016 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000130;
          prmT000130 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000132;
          prmT000132 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000133;
          prmT000133 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00013;
          prmT00013 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00012;
          prmT00012 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000134;
          prmT000134 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorCantidadAsientos",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorEstadoSector",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000135;
          prmT000135 = new Object[] {
          new ParDef("@LugarSectorCantidadAsientos",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorEstadoSector",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000136;
          prmT000136 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000140;
          prmT000140 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000124;
          prmT000124 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000123;
          prmT000123 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000125;
          prmT000125 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000137;
          prmT000137 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000139;
          prmT000139 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00012", "SELECT [EspectaculoId], [LugarSectorCantidadAsientos], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00013", "SELECT [EspectaculoId], [LugarSectorCantidadAsientos], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00014", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00014,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00016", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00017", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00017,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00018", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00018,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00019", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00019,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000110", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000110,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000111", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000112", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoName], TM1.[EspectaculoFecha], T3.[PaisName], T2.[LugarName], T4.[TipoEspectaculoName], TM1.[EspectaculoImagen_GXI], TM1.[LugarId], TM1.[TipoEspectaculoId], T2.[PaisId], TM1.[EspectaculoImagen] FROM ((([Espectaculo] TM1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000112,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000113", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000114", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000114,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000115", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000116", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000117", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] > @EspectaculoId) ORDER BY [EspectaculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000117,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000118", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] < @EspectaculoId) ORDER BY [EspectaculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000119", "INSERT INTO [Espectaculo]([EspectaculoName], [EspectaculoFecha], [EspectaculoImagen], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId]) VALUES(@EspectaculoName, @EspectaculoFecha, @EspectaculoImagen, @EspectaculoImagen_GXI, @LugarId, @TipoEspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000119,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000120", "UPDATE [Espectaculo] SET [EspectaculoName]=@EspectaculoName, [EspectaculoFecha]=@EspectaculoFecha, [LugarId]=@LugarId, [TipoEspectaculoId]=@TipoEspectaculoId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000120)
             ,new CursorDef("T000121", "UPDATE [Espectaculo] SET [EspectaculoImagen]=@EspectaculoImagen, [EspectaculoImagen_GXI]=@EspectaculoImagen_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000121)
             ,new CursorDef("T000122", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000122)
             ,new CursorDef("T000123", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000123,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000124", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000125", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000125,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000126", "SELECT TOP 1 [FuncionId] FROM [Funcion] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000126,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000127", "SELECT [EspectaculoId] FROM [Espectaculo] ORDER BY [EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000127,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000129", "SELECT T2.[LugarId], T1.[EspectaculoId], T2.[LugarSectorName], T1.[LugarSectorCantidadAsientos], T1.[LugarSectorEstadoSector], T2.[LugarSectorPrecio], T1.[LugarSectorId], COALESCE( T3.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (([EspectaculoLugarSector] T1 LEFT JOIN [LugarSector] T2 ON T2.[LugarId] = @LugarId AND T2.[LugarSectorId] = T1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, T4.[LugarSectorId], T5.[EspectaculoId] FROM ([Entrada] T4 INNER JOIN [Funcion] T5 ON T5.[FuncionId] = T4.[FuncionId]) GROUP BY T4.[LugarSectorId], T5.[EspectaculoId] ) T3 ON T3.[LugarSectorId] = T1.[LugarSectorId] AND T3.[EspectaculoId] = T1.[EspectaculoId]) WHERE T1.[EspectaculoId] = @EspectaculoId and T1.[LugarSectorId] = @LugarSectorId ORDER BY T1.[EspectaculoId], T1.[LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000129,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000130", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000130,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000132", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000132,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000133", "SELECT [EspectaculoId], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000133,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000134", "INSERT INTO [EspectaculoLugarSector]([EspectaculoId], [LugarSectorCantidadAsientos], [LugarSectorEstadoSector], [LugarSectorId]) VALUES(@EspectaculoId, @LugarSectorCantidadAsientos, @LugarSectorEstadoSector, @LugarSectorId)", GxErrorMask.GX_NOMASK,prmT000134)
             ,new CursorDef("T000135", "UPDATE [EspectaculoLugarSector] SET [LugarSectorCantidadAsientos]=@LugarSectorCantidadAsientos, [LugarSectorEstadoSector]=@LugarSectorEstadoSector  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000135)
             ,new CursorDef("T000136", "DELETE FROM [EspectaculoLugarSector]  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000136)
             ,new CursorDef("T000137", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000137,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000139", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000139,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000140", "SELECT [EspectaculoId], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000140,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
