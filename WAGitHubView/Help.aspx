<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="Help.aspx.cs" Inherits="WebAppGitHubView.Help" %>

<asp:Content ID="ContentHelpHeader" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="ContentHelpBody" ContentPlaceHolderID="default" runat="server">
    <div class="help">
        <h3 style="color: peru">Как пользоваться таблицей и ресурсом</h3>
        <div class="text">
            <p>
                Данный ресурс представляет 2 варианта работы с репозиториями:<br />
                1 Для просмотра всех репозиториев (public and private), но при условии проверки подлинности.<br />
                2 Для просмотра public репозиториев без проверки подлинности.
       
            <p>
                Для 1 варианта работы необходимо в строке браузера ввести "localhost/githubview/Default.aspx", где githubview - 
            номер порта либо название фолдера, после чего загрузится страница где необходимо ввести логин пользователя
            github и пароль. При нажатии на кнопку "SUBMIT" загрузиться страница со всеми репозиториями.
       
            </p>
            <p>
                Для второго варианта работы также в строке браузера вводим "localhost/githubview/List.aspx", после чего загрузиться 
            страница с готовым листом репозиториев. Вы можете добавлять или удалять строки, или изменять значения в таблице,
                для этого необходимо нажать кнопку "ACTIVATION" (при первой загрузке текстовое поле будет заблокированно).
                 Отредактируете таблицу как захотите.<br />
                Что бы начать работу с редактированием таблици (добавление, удаление и редактирование) нужно активировать
             текстовое поле при нажатии на клавишу ACTIVATION. После чего текстовое поле активируеться и мы можем в него вставлять
            нужный(https://github.com) url адрес.
               
                <br />
                Для удаление или изменения ячейки, при условии, что текстовое поле разблокированное, кликаем по нужной ячейке. После
            этого в тектовом поле появиться текст нажатой ячейки. Далее можно вставить(ADD), удалить(REMOVE), а если редактировать
            то изменить текст в текстовом поле и нажать кнопку EDIT.
           
            </p>
            <p>
                Когда проиcходит добавление или удаление или редактирование таблици текстовое поле блокируеться.
           
            </p>
            <p>
                Для просмотра информации по репозиториям, которые находятся в таблице, нажмите кнопку "INFO", после чего загрузится
                 информация о всех репозиториях в таблице. Для возврата на страницу редактирования таблици нажмите кнопку "BACK" или
                с помощью браузера кнопка со стрелочкой в лево.
            </p>
            <p>
                Для правильной публикации веб приложения на IIS посмотрите <a style="text-decoration: none;" href="http://metanit.com/sharp/mvc/13.2.php">пример</a> .
           
            </p>
            <p>
                Если клиентский запрос к веб-сайту не содержит имени документа, службы IIS ищут файл, имя которого определено в качестве документа по умолчанию.
                 Обычно именем документа по умолчанию является Default.htm.
                 Можно <a style="text-decoration: none;" href="https://technet.microsoft.com/ru-ru/library/hh831515.aspx">определить список имен документов</a> по умолчанию в порядке старшинства.
            </p>
        </div>


        <h3 style="color: peru">How to use the table and resource</h3>
        <div class="text">
            <p>
                This resource is 2 options working with repositories:
                    <br />
                1 To view all repositories (public and private), but subject to authentication.
                    <br />
                2 To view the public repositories without authentication.
       
                <p>
                    1 option for the work needed in your browser enter "localhost / githubview / Default.aspx", where githubview - port number or folder name, and then loaded page where you must enter the User ID 
                    github and password. When you click on "SUBMIT" to load the page with all the repositories.
       
                </p>
            <p>
                For the second option in your browser, enter "localhost / githubview / List.aspx", then boot page with a finished sheet repositories. You can add or delete rows, or to change the values in the table, to do this, press the "ACTIVATION" (when you first load the text box will be locked). Edit the table as you want.
                    <br />
                To get started with editing tables (adding, deleting, and editing) must be activated text box when you press ACTIVATION. Then activate the text field and we can put into it right (https://github.com) url address.
               
                    <br />
                To delete or change a cell, provided that the text box is unlocked, click on the desired cell. after in this text field text to appear down the cell. Further it is possible to insert (ADD), delete (REMOVE), and if the edit then change the text in the text box and click EDIT.
           
            </p>
            <p>
                When an addition or removal or editing a table text box blocking.
           
            </p>
            <p>
                To view information on the repositories that are in the table, press the "INFO", then download information about all repositories in the table. To return to the edit page of the spreadsheet, click the "BACK" button or using the browser button with an arrow to the left.
            </p>
            <p>
                For proper publication of a web application on IIS see an <a style="text-decoration: none;" href="http://metanit.com/sharp/mvc/13.2.php">example</a> .
           
            </p>
            <p>
                If a client request to a Web site does not contain the name of the document, IIS looking for a file whose name is specified as the default document. Typically, the name of the default document is Default.htm.
                 You can define a list of names of <a style="text-decoration: none;" href="https://technet.microsoft.com/ru-ru/library/hh831515.aspx">default documents</a> in the order of precedence.
            </p>
        </div>
    </div>


</asp:Content>

