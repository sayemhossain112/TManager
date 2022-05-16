<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="TuitionManagement.homepage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="style.css" rel="stylesheet" />
    <section class="hero-section">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div class="aside-text">
                        <h1>Your new way of using mobile</h1>
                        <p>Spend time wisely and get productive.</p>
                        <asp:Button Text="Get Started" runat="server" CssClass="btn btn-primary home-btn" />
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="hero-image">
                        <img src="https://assets.codepen.io/845908/12+Devices.png" alt="Alternate Text" />
                    </div>
                </div>
            </div>
        </div>
    </section>


    <%-- <section>
       <center>
         <img src="img/adami.jpg" class="img-fluid" width="1980" height="220" />
       </center>
   </section>--%>


    <style>
        .home-card svg {
            font-size: 50px !important;
            margin-top: 20px !important;
        }

        .home-card {
            box-shadow: 0 0 10px #9ea8b578;
            transition: 0.5s;
            margin: auto;
        }

            .home-card:hover {
                box-shadow: 0 0 10px #40536abd;
                transition: 0.5s;
            }

        .jumbotron-image {
            background-position: center center;
            background-repeat: no-repeat;
            background-size: cover;
        }

        .full-image img {
            width: 100%;
        }

        .middle-text {
            width: 80%;
            margin-top: 40px;
        }




    </style>

    



    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <div class="card home-card" style="width: 18rem;">
                        <center>
                            <i class="fas fa-tasks"></i>
                            <div class="card-body">
                                <h5 class="card-title">Attendace</h5>
                                <p class="card-text">It's simple to keep track of absentees in a variety of methods and still know who they are!</p>
                            </div>
                        </center>


                    </div>

                </div>
                <div class="col-md-4">
                    <div class="card  home-card" style="width: 18rem;">
                        <center>
                            <i class="fas fa-user-cog"></i>
                            <div class="card-body">
                                <h5 class="card-title">Management</h5>
                                <p class="card-text">Use our handy school tuition management system  to keep track of your class's progress </p>
                            </div>
                        </center>
                    </div>

                </div>
                <div class="col-md-4">
                    <div class="card  home-card" style="width: 18rem;">
                        <center>
                            <i class="fab fa-readme"></i>
                            <div class="card-body">
                                <h5 class="card-title">Learning</h5>
                                <p class="card-text">Management of courses would involve the offering of certain classes, courses, or batches</p>
                            </div>
                        </center>

                    </div>

                </div>
            </div>
        </div>



    </section>



    <section>
        <div class="container">

            <div class="row">
                <div class="col-md-6">
                    <div class="middle-text">
                        <h1>Lorem ipsum dolor sit amet consectetur.</h1>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Reiciendis optio odit non recusandae magnam tenetur, numquam sunt asperiores. Recusandae quidem pariatur nemo vitae assumenda?</p>

                    </div>
                </div>
                <div class="col-md-6 full-image">
                    <img src="https://assets.codepen.io/845908/12+Devices.png" alt="">
                </div>
            </div>

        </div>
    </section>


    <section>
        <div class="container py-5">
            <div class="jumbotron text-white jumbotron-image shadow" style="background-image: url(https://images.unsplash.com/photo-1552152974-19b9caf99137?fit=crop&w=1350&q=80);">
                <h2 class="mb-4">Jumbotron with background image
                </h2>
                <p class="mb-4">
                    Hey, check this out.
                </p>
                <a href="https://bootstrapious.com/snippets" class="btn btn-primary">More Bootstrap Snippets</a>
            </div>
        </div>
    </section>

</asp:Content>
