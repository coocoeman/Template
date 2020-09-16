<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="Template.Game" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--=====================================================
					Game Menu Section
				=====================================================-->
				<section id='game' class='section portfolio-section active' >
					
					<div class='section-block portfolio-block' >
						
						<div class='container-fluid' >
							
							
							<div class='section-header' >
								<h2>遊戲多多快樂多多 <strong class='color' >GameMenu</strong></h2>
							</div>
							
							<ul class='portfolio-filters' >
								<li>
									<a href='#' class='active' data-group='all' >
										全部遊戲
									</a>
								</li>
								<li>
									<a href='#' data-group='web' >
									</a>
								</li>
								<li>
									<a href='#' data-group='tech' >
									</a>
								</li>
								<li>
									<a href='#' data-group='photography' >
									</a>
								</li>
							</ul>
							
							<ul class='portfolio-items' >
								
								<li data-groups='["web","tech"]' >
									<div class='inner' >
										<img src='img/portfolio/1.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-1' class='view-project' >
												遊戲1
											</a>
											
										</div>
										
									</div>
								</li>
								
								<li data-groups='["tech","photography"]' >
									<div class='inner' >
										<img src='img/portfolio/2.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-2' class='view-project' >
												遊戲2
											</a>
											
										</div>
										
									</div>
								</li>
								
								<li data-groups='["web","photography"]' >
									<div class='inner' >
										<img src='img/portfolio/3.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-3' class='view-project' >
												遊戲3
											</a>
										
										</div>
										
									</div>
								</li>
								
								
								<li data-groups='["web"]' >
									<div class='inner' >
										<img src='img/portfolio/4.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-4' class='view-project' >
												遊戲4
											</a>
								
										</div>
										
									</div>
								</li>
								
								<li data-groups='["tech"]' >
									<div class='inner' >
										<img src='img/portfolio/5.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-5' class='view-project' >
												遊戲5
											</a>
								
										</div>
										
									</div>
								</li>
								
								<li data-groups='["photography"]' >
									<div class='inner' >
										<img src='img/portfolio/6.jpg' alt>
										
										<div class='overlay' >
											
											<a href='#popup-6' class='view-project' >
												遊戲6
											</a>
						
										</div>
										
									</div>
								</li>
								
							</ul>
							
						</div>
					
					</div>
					
				</section>
</asp:Content>