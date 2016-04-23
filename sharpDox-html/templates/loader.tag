<sd-loader>

    <i if={ gettingPage } id="loader" class="icon-refresh icon-spin"></i>
    
    <style scoped>
        #loader{
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: white;
            text-align: center;
            padding-top:250px;
        }

        i{
            margin:auto;
        }
    </style>
    
</sd-loader>