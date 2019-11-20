<%@ Page Title="" Language="C#" MasterPageFile="~/Guest.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="CheckCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .cart_info .cart_menu {
    background: #FE980F;
    color: #fff;
    font-size: 16px;
    font-family: 'Roboto', sans-serif;
    font-weight: normal;
    padding-top: 10px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="step-one">
				<h2 class="heading">Step1</h2>
			</div>
    <div class="checkout-options">
				<h3>New User</h3>
				<p>Checkout options</p>
				<ul class="nav">
					
					<li>
						<label><input type="checkbox" checked> Guest Checkout</label>
					</li>
					<li>
						<a href="home.aspx"><i class="fa fa-times"></i>Cancel</a>
					</li>
				</ul>
			</div>
    <div class="shopper-informations">
				<div class="row">
					<div class="col-sm-3">
						<div class="shopper-info">
							<p>Shopper Information</p>
							
								Address:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <br />
								Mobile:&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<br />
						<asp:Button ID="Button1" runat="server" Text="Submit Order" class='btn btn-fefault cart' OnClick="Button1_Click" />
                                
						</div>
					</div>
							
				</div>
			</div>



    <div class="table-responsive cart_info">
				<table class="table table-condensed">
					<thead>
						<tr class="cart_menu">
							<td class="image">Item</td>
							<td class="description">Description</td>
							<td class="price">Price</td>
							<!--<td class="quantity">Quantity</td>
							<td class="total">Total</td>-->
							<td></td>
						</tr>
					</thead>
					<tbody>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
						<!--<tr>
							<td class="cart_product">
								<a href=""><img src="images/cart/one.png" alt=""></a>
							</td>
							<td class="cart_description">
								<h4><a href="">Colorblock Scuba</a></h4>
								<p>Web ID: 1089772</p>
							</td>
							<td class="cart_price">
								<p>$59</p>
							</td>
							
							
							<td class="cart_delete">
								<a class="cart_quantity_delete" href=""><i class="fa fa-times"></i></a>
							</td>
						</tr>

                        
						<tr>
							<td class="cart_product">
								<a href=""><img src="images/cart/two.png" alt=""></a>
							</td>
							<td class="cart_description">
								<h4><a href="">Colorblock Scuba</a></h4>
								<p>Web ID: 1089772</p>
							</td>
							<td class="cart_price">
								<p>$59</p>
							</td>
							<td class="cart_quantity">
								<div class="cart_quantity_button">
									<a class="cart_quantity_up" href=""> + </a>
									<input class="cart_quantity_input" type="text" name="quantity" value="1" autocomplete="off" size="2">
									<a class="cart_quantity_down" href=""> - </a>
								</div>
							</td>
							<td class="cart_total">
								<p class="cart_total_price">$59</p>
							</td>
							<td class="cart_delete">
								<a class="cart_quantity_delete" href=""><i class="fa fa-times"></i></a>
							</td>
						</tr>
						<tr>
							<td class="cart_product">
								<a href=""><img src="images/cart/three.png" alt=""></a>
							</td>
							<td class="cart_description">
								<h4><a href="">Colorblock Scuba</a></h4>
								<p>Web ID: 1089772</p>
							</td>
							<td class="cart_price">
								<p>$59</p>
							</td>
							<td class="cart_quantity">
								<div class="cart_quantity_button">
									<a class="cart_quantity_up" href=""> + </a>
									<input class="cart_quantity_input" type="text" name="quantity" value="1" autocomplete="off" size="2">
									<a class="cart_quantity_down" href=""> - </a>
								</div>
							</td>
							<td class="cart_total">
								<p class="cart_total_price">$59</p>
							</td>
							<td class="cart_delete">
								<a class="cart_quantity_delete" href=""><i class="fa fa-times"></i></a>
							</td>
						</tr>-->
                        <tr>
                            <td colspan="3" align="right">
                                &nbsp;</td>
                            <td align="left">
                                <span class="total">$Total</span>
                            </td>
                        </tr>
					</tbody>
				</table>
			</div>
</asp:Content>

