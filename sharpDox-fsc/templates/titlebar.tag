<sd-titlebar>

    <h2 if={ currentPageType === 'article' }>{ currentPageData.title }</h2>
    <h3 if={ currentPageType === 'article' }>{ currentPageData.subTitle }</h3>

    <h2 if={ currentPageType === 'namespace' }>{ currentPageData.name }</h2>
    <h3 if={ currentPageType === 'namespace' }>{ sharpDox.strings.assembly }: { currentPageData.assembly }</h3>

    <h2 if={ currentPageType === 'type' }>{ currentPageData.name }</h2>
    <h3 if={ currentPageType === 'type' }>{ sharpDox.strings.namespace }: { currentPageData.namespace }</h3>

    <style scoped>
        :scope{
            display: block;
            margin: 20px 0 25px;
            min-height: 50px;
            text-align: center;
        }

        h2{
            margin: 0;
        }

        h3{
            font-size: 0.75em;
            color:gray;
            margin: 10px 0 0;
        }
    </style>

</sd-titlebar>