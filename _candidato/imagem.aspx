<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/candidato.master" AutoEventWireup="false" CodeFile="imagem.aspx.vb" Inherits="_candidato_imagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <script type="text/javascript">
         function GetMensagem() {
             $("input[id$='cropOutputRunatServer']").val($("#cropOutput").val());
             var myButton = document.getElementById('ButtonTr');
             var myvalor = ($("#cropOutput").val());
             if (myvalor != '') {
                 myButton.style.display = 'none'
                 document.getElementById("avisoImagem").innerHTML = ""
             }
             else {
                 document.getElementById("avisoImagem").innerHTML = "Você precisa preparar uma imagem para este produto.";
             }
         }
    </script>
        
<section id="content"><div class="ic">OportunidadesBH</div>
  <div class="container">
     <div class="grid_12">
        <h3 class="head__1">Atualizar foto do perfil</h3>

         <form id="contact_form" runat="server" class="_placeholder">         


            <div class="col-lg-3 ">
				<h4 class="centered"><asp:Label ID="LabelTextoImagem" runat="server" Text="Atualizar foto"></asp:Label></h4>
				<p class="centered"><asp:Label ID="LabelTextoImagemAviso" runat="server" Text="( Ajuste a sua foto )"></asp:Label></p>
				<div id="cropContaineroutput"></div>
				<input type="text" id="cropOutput" hidden="hidden" />
                <input type="text" runat="server" id="cropOutputRunatServer" hidden="hidden" />
                <asp:Button ID="ButtonAPROVADO" runat="server" Text="Gravar" OnClientClick="GetMensagem()" CssClass="btn" />
            </div>


         </form>
      </div>
    </div>
    </section>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <!-- <script src="https://code.jquery.com/jquery-1.10.2.min.js"></script> -->
	<script src=" https://code.jquery.com/jquery-2.1.3.min.js"></script>
   
	<script src="../assets/js/bootstrap.min.js"></script>
	<script src="../assets/js/jquery.mousewheel.min.js"></script>
   	<script src="../croppic.min.js"></script>
    <script src="../assets/js/main.js"></script>
    <script>
		var croppicHeaderOptions = {
				//uploadUrl:'img_save_to_file.php',
				cropData:{
					"dummyData":1,
					"dummyData2": "text"
				},
				cropUrl:'img_crop_to_file.php',
				customUploadButtonId:'cropContainerHeaderButton',
				modal:false,
				processInline:true,
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> ',
				onBeforeImgUpload: function(){ console.log('onBeforeImgUpload') },
				onAfterImgUpload: function(){ console.log('onAfterImgUpload') },
				onImgDrag: function(){ console.log('onImgDrag') },
				onImgZoom: function(){ console.log('onImgZoom') },
				onBeforeImgCrop: function(){ console.log('onBeforeImgCrop') },
				onAfterImgCrop:function(){ console.log('onAfterImgCrop') },
				onError:function(errormessage){ console.log('onError:'+errormessage) }
		}	
		var croppic = new Croppic('croppic', croppicHeaderOptions);
		
		
		var croppicContainerModalOptions = {
				uploadUrl:'img_save_to_file.php',
				cropUrl:'img_crop_to_file.php',
				modal:true,
				imgEyecandyOpacity:0.4,
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
		}
		var cropContainerModal = new Croppic('cropContainerModal', croppicContainerModalOptions);
		
		
		var croppicContaineroutputOptions = {
				uploadUrl:'img_save_to_file.php',
				cropUrl:'img_crop_to_file.php', 
				outputUrlId: 'cropOutput',
				modal:true,
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
		}
		var cropContaineroutput = new Croppic('cropContaineroutput', croppicContaineroutputOptions);
		
		var croppicContainerEyecandyOptions = {
				uploadUrl:'img_save_to_file.php',
				cropUrl:'img_crop_to_file.php',
				imgEyecandy:false,				
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
		}
		var cropContainerEyecandy = new Croppic('cropContainerEyecandy', croppicContainerEyecandyOptions);
		
		var croppicContaineroutputMinimal = {
				uploadUrl:'img_save_to_file.php',
				cropUrl:'img_crop_to_file.php', 
				modal:false,
				doubleZoomControls:false,
			    rotateControls: false,
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
		}
		var cropContaineroutput = new Croppic('cropContainerMinimal', croppicContaineroutputMinimal);
		
		var croppicContainerPreloadOptions = {
				uploadUrl:'img_save_to_file.php',
				cropUrl:'img_crop_to_file.php',
				loadPicture:'../assets/img/night.jpg',
				enableMousescroll:true,
				loaderHtml:'<div class="loader bubblingG"><span id="bubblingG_1"></span><span id="bubblingG_2"></span><span id="bubblingG_3"></span></div> '
		}
		var cropContainerPreload = new Croppic('cropContainerPreload', croppicContainerPreloadOptions);
		
		
	</script>

</asp:Content>

