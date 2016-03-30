<sd-header>
    
    <a href="#!" if={ hasLogo }><img src="data/logo.png" alt="{ projectName }"/></a>
    <a href="#!" if={ !hasLogo }><h1>{ projectName }</h1></a>
    
    <style scoped>
        :scope {
            display:block;
            margin: 35px 0px;
            height: 50px;
        }

        a{
            display:block;
            text-align:center;
        }

        a img{
            max-height:50px;
        }

        h1{
            margin:0;
            padding:0;
        }

    </style>
    
</sd-header>