<sd-fxChanger>

    <select onchange={ setTargetFx }>
        <option each={ item in currentPageTargetFxs }>{ item }</option>
    </select>
    <div style="clear:both;"></div>

    <style scoped>
        :scope{
            margin-bottom: 15px;
            display:block;
            float:right;
        }

        select{
            padding: 5px;
            font-size: 0.7em;
        }

        option{
            padding:5px;
        }
    </style>

</sd-fxChanger>