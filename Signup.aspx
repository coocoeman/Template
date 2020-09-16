<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Template.Signup" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <section id='login' class='section contact-section active' >
					
					<div class='section-block contact-block' >
						
						<div class='container-fluid' >
							
							<div class='section-header' >
								<h2>未滿18歲請勿註冊 <strong class='color' >註冊</strong></h2>
							</div>
							
							<div class='row' >
							
								<div class='col-md-8' >
									
									<div class='contact-form' >
									
										<form method='post' action="Login">
										
											
										
											<div class='row' >
												
												<div class='col-md-8' >
													<div class='form-group' >
														
														<input type='text' class='form-control' placeholder='帳號' name='account' required>
														
													</div>												
												</div>
					
											</div>
											
											<div class='col-md-8' >
													<div class='form-group' >
														
														<input type="password" class='form-control' placeholder='密碼' name='password' required>
														
													</div>												
												</div>
											<div class='col-md-8' >
											<div class='form-group text-center' >
												<button type='submit' class='btn-custom btn-color'>
													登入
												</button>
												<a href='/Signup' class='btn-custom btn-color' >
													我要註冊
												</a>
											</div>
											</div>
											
										</form>
										
									</div>
									
									
								</div>
								
								<div class='col-md-4' >
									
									<div class='contact-info-icons' >
										
										
										
										
										
										
										
										
										
										
										
										
									</div>
									
									
									
								</div>
								
								
							</div>
							
							
							
						</div>
					
					</div>
					
				</section>


</asp:Content>
