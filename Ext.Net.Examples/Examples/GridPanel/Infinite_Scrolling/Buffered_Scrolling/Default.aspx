<%@ Page Language="C#" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            this.Store1.DataSource = this.TestData(5000);
            this.Store1.DataBind();
        }
    }

    private object[] TestData(int count)
    {
        string[] firstNames = new string[] { "Ed", "Tommy", "Aaron", "Abe", "Jamie", "Adam", "Dave", "David", "Jay", "Nicolas", "Nige" };
        string[] lastNames = new string[] { "Spencer", "Maintz", "Conran", "Elias", "Avins", "Mishcon", "Kaneda", "Davis", "Robinson", "Ferrero", "White" };
        int[] ratings = new int[] { 1, 2, 3, 4, 5 };
        int[] salaries = new int[] { 100, 400, 900, 1500, 1000000 };

        object[] data = new object[count];
        Random rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            int ratingId = rnd.Next(ratings.Length);
            int salaryId = rnd.Next(salaries.Length);
            int firstNameId = rnd.Next(firstNames.Length);
            int lastNameId = rnd.Next(lastNames.Length);

            int rating = ratings[ratingId];
            int salary = salaries[salaryId];
            string name = String.Format("{0} {1}", firstNames[firstNameId], lastNames[lastNameId]);
            string id = "rec-" + i;

            data[i] = new object[] { id, name, rating, salary };
        }

        return data;
    }
</script>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Buffered Scrolling - Ext.NET Examples</title>
    <link href="/resources/css/examples.css" rel="stylesheet" />

    <script>
        var go = function () {
            var me = this,
                field = me.up('toolbar').down('#gotoLine'); 
            
            if (field.isValid()) { 
                me.up('grid').verticalScroller.scrollTo(field.getValue() - 1, true); 
            }
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <h1>Buffered Scrolling</h1>

        <p>Ext.Net 2's brand new grid supports infinite scrolling, which enables you to load any number of records into a grid without paging.</p>

        <p>The new grid uses a virtualized scrolling system to handle potentially infinite data sets without any impact on client side performance.</p>

        <p>This example illustrates loading of all the records up front and buffering the rendering.</p>
        
        <ext:GridPanel 
            runat="server" 
            Title="Bufffered Grid of 5,000 random records"             
            Width="700" 
            Height="500">
            <Store>
                <ext:Store 
                    ID="Store1" 
                    runat="server" 
                    PageSize="5000" 
                    Buffered="true">                    
                    <Model>
                        <ext:Model runat="server">
                            <Fields>
                                <ext:ModelField Name="id" />
                                <ext:ModelField Name="name" />
                                <ext:ModelField Name="rating" Type="Int" />
                                <ext:ModelField Name="salary" Type="Float" />
                            </Fields>
                        </ext:Model>
                    </Model>            
                </ext:Store>
            </Store>            
            <View>
                <ext:GridView runat="server" TrackOver="false" />
            </View>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" PruneRemoved="false" />
            </SelectionModel>
            <ColumnModel runat="server">
                <Columns>
                    <ext:RowNumbererColumn 
                        runat="server" 
                        Width="40" 
                        Sortable="false" />
                    <ext:Column 
                        runat="server" 
                        Text="Name" 
                        Flex="1" 
                        DataIndex="name" />
                    <ext:Column 
                        runat="server" 
                        Text="Rating" 
                        Width="125" 
                        DataIndex="rating" />
                    <ext:Column 
                        runat="server" 
                        Text="Salary" 
                        Width="125" 
                        DataIndex="salary" 
                        Align="Right">
                        <Renderer Format="UsMoney" />
                    </ext:Column>                    
                </Columns>
            </ColumnModel>     
            <BottomBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:NumberField 
                            runat="server"
                            FieldLabel="Jump to row"
                            MinValue="1"
                            MaxValue="5000"
                            AllowDecimals="false"
                            ItemId="gotoLine"/>

                        <ext:Button runat="server" Text="Go">
                            <Listeners>
                                <Click Fn="go" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </BottomBar>       
        </ext:GridPanel>
    </form>
</body>
</html>
