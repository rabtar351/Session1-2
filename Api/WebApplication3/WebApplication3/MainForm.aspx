<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="WebApplication3.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="style.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="Logo">
                <img src ="Logo.png"/>
            </div>
            <input type="text" class="search-bar" placeholder="Введите для поиска"/>

        </div>

        <div class="content">
            <h2>Сотрудники</h2>
            <div class="employees" id="employeeList" runat="server">
            </div>
        </div>

        <section>
            <div class="calendar-event-sn">
                <h2>Календарь событий</h2>
                <div>
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </div>
                <h2>События</h2>
                <div class="event">
                    <div class="event-list" runat="server" id="eventList"></div>
                </div>
            </div>
            <div class="news-sn">
                <h2>Новости</h2>
                <div class="news-card-list" runat="server" id="newsCardList">
                </div>
            </div>
        </section>
    </form>
</body>
</html>
