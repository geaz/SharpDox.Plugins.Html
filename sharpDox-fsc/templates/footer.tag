<sd-footer>
    
    <div id="footer-left">{ footerLine }</div>
    <div id="footer-right">
        <a if={ homepage } href="{ homepage }" title="{ projectName }" target="_blank">{ projectName }</a>
        <span if={ !homepage }>{ projectName }</span> { version }
        <span if={ author }>- {author}</span> - { generatedBy } <a href="http://sharpdox.de" title="sharpDox" target="_blank">sharpDox</a>
    </div>
    
    <style scoped>
        :scope{
            display:block;
            border-top: 1px solid #bbb;
            color: gray;
            font-size: 0.75em;
            margin-bottom: 25px;
        }

        #footer-left{
            float:left;
        }

        #footer-right{
            float:right;
        }
    </style>

</sd-footer>