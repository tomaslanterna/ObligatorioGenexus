gx.evt.autoSkip=!1;gx.define("wwinvitacion",!1,function(){var n,t;this.ServerClass="wwinvitacion";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwinvitacion.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A3PaisId=gx.fn.getIntegerValue("PAISID",".")};this.Validv_Invitacionfecha=function(){return this.validCliEvt("Validv_Invitacionfecha",0,function(){try{var n=gx.util.balloon.getNew("vINVITACIONFECHA");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11InvitacionFecha)===0||new gx.date.gxdate(this.AV11InvitacionFecha).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Campo Invitacion Fecha fuera de rango");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Espectaculoid=function(){var n=gx.fn.currentGridRowImpl(25);return this.validCliEvt("Valid_Espectaculoid",25,function(){try{if(gx.fn.currentGridRowImpl(25)===0)return!0;var n=gx.util.balloon.getNew("ESPECTACULOID",gx.fn.currentGridRowImpl(25));this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11192_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e15192_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e16192_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,23,24,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",25,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwinvitacion",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","Nueva fila",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(24,26,"INVITACIONID","Id","","InvitacionId","int",0,"px",4,4,"right",null,[],24,"InvitacionId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(25,27,"INVITACIONFECHA","Fecha","","InvitacionFecha","date",0,"px",8,8,"right",null,[],25,"InvitacionFecha",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(1,28,"ESPECTACULOID","Espectaculo Id","","EspectaculoId","int",0,"px",4,4,"right",null,[],1,"EspectaculoId",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(2,29,"ESPECTACULONAME","Espectaculo Name","","EspectaculoName","svchar",0,"px",40,40,"left",null,[],2,"EspectaculoName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(6,30,"PAISNAME","Pais Name","","PaisName","svchar",0,"px",40,40,"left",null,[],6,"PaisName",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addCheckBox(36,31,"INVITACIONNOMINADA","Nominada","","InvitacionNominada","boolean","true","false",null,!0,!1,0,"px","WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",32,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",33,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e11192_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Invitacionfecha,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.GridContainer],fld:"vINVITACIONFECHA",fmt:0,gxz:"ZV11InvitacionFecha",gxold:"OV11InvitacionFecha",gxvar:"AV11InvitacionFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11InvitacionFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11InvitacionFecha=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vINVITACIONFECHA",gx.O.AV11InvitacionFecha,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11InvitacionFecha=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vINVITACIONFECHA")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"GRIDCELL",grid:0};n[19]={id:19,fld:"GRIDTABLE",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[26]={id:26,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVITACIONID",fmt:0,gxz:"Z24InvitacionId",gxold:"O24InvitacionId",gxvar:"A24InvitacionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A24InvitacionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24InvitacionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("INVITACIONID",n||gx.fn.currentGridRowImpl(25),gx.O.A24InvitacionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A24InvitacionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("INVITACIONID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVITACIONFECHA",fmt:0,gxz:"Z25InvitacionFecha",gxold:"O25InvitacionFecha",gxvar:"A25InvitacionFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A25InvitacionFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z25InvitacionFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("INVITACIONFECHA",n||gx.fn.currentGridRowImpl(25),gx.O.A25InvitacionFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A25InvitacionFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("INVITACIONFECHA",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:this.Valid_Espectaculoid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULOID",fmt:0,gxz:"Z1EspectaculoId",gxold:"O1EspectaculoId",gxvar:"A1EspectaculoId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EspectaculoId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),gx.O.A1EspectaculoId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1EspectaculoId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ESPECTACULOID",n||gx.fn.currentGridRowImpl(25),".")},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ESPECTACULONAME",fmt:0,gxz:"Z2EspectaculoName",gxold:"O2EspectaculoName",gxvar:"A2EspectaculoName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2EspectaculoName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EspectaculoName=n)},v2c:function(n){gx.fn.setGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25),gx.O.A2EspectaculoName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2EspectaculoName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ESPECTACULONAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNAME",fmt:0,gxz:"Z6PaisName",gxold:"O6PaisName",gxvar:"A6PaisName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A6PaisName=n)},v2z:function(n){n!==undefined&&(gx.O.Z6PaisName=n)},v2c:function(n){gx.fn.setGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25),gx.O.A6PaisName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A6PaisName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAISNAME",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"boolean",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"INVITACIONNOMINADA",fmt:0,gxz:"Z36InvitacionNominada",gxold:"O36InvitacionNominada",gxvar:"A36InvitacionNominada",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A36InvitacionNominada=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z36InvitacionNominada=gx.lang.booleanValue(n))},v2c:function(n){gx.fn.setGridCheckBoxValue("INVITACIONNOMINADA",n||gx.fn.currentGridRowImpl(25),gx.O.A36InvitacionNominada,!0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A36InvitacionNominada=gx.lang.booleanValue(this.val(n)))},val:function(n){return gx.fn.getGridControlValue("INVITACIONNOMINADA",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn,values:["true","false"]};n[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",fmt:0,gxz:"ZV12Update",gxold:"OV12Update",gxvar:"AV12Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25),gx.O.AV12Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:25,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",fmt:0,gxz:"ZV13Delete",gxold:"OV13Delete",gxvar:"AV13Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25),gx.O.AV13Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(25))},nac:gx.falseFn};this.AV11InvitacionFecha=gx.date.nullDate();this.ZV11InvitacionFecha=gx.date.nullDate();this.OV11InvitacionFecha=gx.date.nullDate();this.Z24InvitacionId=0;this.O24InvitacionId=0;this.Z25InvitacionFecha=gx.date.nullDate();this.O25InvitacionFecha=gx.date.nullDate();this.Z1EspectaculoId=0;this.O1EspectaculoId=0;this.Z2EspectaculoName="";this.O2EspectaculoName="";this.Z6PaisName="";this.O6PaisName="";this.Z36InvitacionNominada=!1;this.O36InvitacionNominada=!1;this.ZV12Update="";this.OV12Update="";this.ZV13Delete="";this.OV13Delete="";this.AV11InvitacionFecha=gx.date.nullDate();this.A3PaisId=0;this.A4LugarId=0;this.A24InvitacionId=0;this.A25InvitacionFecha=gx.date.nullDate();this.A1EspectaculoId=0;this.A2EspectaculoName="";this.A6PaisName="";this.A36InvitacionNominada=!1;this.AV12Update="";this.AV13Delete="";this.Events={e11192_client:["'DOINSERT'",!0],e15192_client:["ENTER",!0],e16192_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionFecha",fld:"vINVITACIONFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms["GRID.LOAD"]=[[{av:"A24InvitacionId",fld:"INVITACIONID",pic:"ZZZ9",hsh:!0},{av:"A1EspectaculoId",fld:"ESPECTACULOID",pic:"ZZZ9"},{av:"A3PaisId",fld:"PAISID",pic:"ZZZ9"}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"},{av:'gx.fn.getCtrlProperty("INVITACIONFECHA","Link")',ctrl:"INVITACIONFECHA",prop:"Link"},{av:'gx.fn.getCtrlProperty("ESPECTACULONAME","Link")',ctrl:"ESPECTACULONAME",prop:"Link"},{av:'gx.fn.getCtrlProperty("PAISNAME","Link")',ctrl:"PAISNAME",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A24InvitacionId",fld:"INVITACIONID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionFecha",fld:"vINVITACIONFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionFecha",fld:"vINVITACIONFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionFecha",fld:"vINVITACIONFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11InvitacionFecha",fld:"vINVITACIONFECHA",pic:""},{av:"AV12Update",fld:"vUPDATE",pic:""},{av:"AV13Delete",fld:"vDELETE",pic:""}],[]];this.EvtParms.VALIDV_INVITACIONFECHA=[[],[]];this.EvtParms.VALID_ESPECTACULOID=[[],[]];this.setVCMap("A3PaisId","PAISID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm({rfrVar:"AV12Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV13Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwinvitacion)})