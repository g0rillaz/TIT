<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="TIT.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">




  <div class="container">

      <div class="container">
  <div class="row">


    <div class="col-sm-9">
        <div class="btn-group">

        <div class="dropdown">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        Region
            </button>  

            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        Station
            </button>  
        </div>
            </div>


        <div class="btn-group">
        <div class="dropdown">
            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        Interval
            </button>  

            <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        Order By
            </button>  
        </div>
        </div>
    </div>


    <div class="col-sm-3">
      <div class="form-check">
                  <input class="form-check-input" type="checkbox" value="" id="Raw_Temperature">
            <label class="form-check-label" for="Raw_Temperature">Raw Temperature
                </label>
                    </div>

          <div class="form-check">
             <input class="form-check-input" type="checkbox" value="" id="Mean_Temperature">
            <label class="form-check-label" for="Mean_Temperature">
                Mean Temperature
                </label>
        </div>

                      <div class="form-check">
      
           <input class="form-check-input" type="checkbox" value="" id="Median_Temperature">
            <label class="form-check-label" for="Median_Temperature">
                Median Temperature
                </label>
      </div>
                  <div class="form-check">

                            <input class="form-check-input" type="checkbox" value="" id="Min_Temperature">
            <label class="form-check-label" for="Min_Temperature">
                Min Temperature
                </label>
          </div>

                  <div class="form-check">

                            <input class="form-check-input" type="checkbox" value="" id="Max_Temperature">
            <label class="form-check-label" for="Max_Temperature">
                Max Temperature
                </label>
      </div>
                  <div class="form-check">

                            <input class="form-check-input" type="checkbox" value="" id="Standard_Devitaion">
            <label class="form-check-label" for="Standard_Devitaion">Standard Devitaion
                </label>
    </div>
                  <div class="form-check">

                            <input class="form-check-input" type="checkbox" value="" id="Mode_Temperature">
            <label class="form-check-label" for="Mode_Temperature">Mode Temperature
                </label>
    </div>
                  <div class="form-check">

        <input class="form-check-input" type="checkbox" value="" id="Range_Temperature">
            <label class="form-check-label" for="Range_Temperature">Range Temperature
                </label>            
        </div>

    </div>
  </div>
</div>


</div>

  </div>
</div>





      </div>
</asp:Content>
