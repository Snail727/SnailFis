<template>
    <div>
        <span v-if="bool1"></span>
        <span v-else-if="!bool1"></span> 
        <span v-else></span>
        <span v-show="bool1"></span>

        <ol>
            <li v-for="(item,index) in arr1" :key="item.id">{{item.id}}--{{item.name}}--{{index}}</li>
        </ol>
        <ol>
            <li v-for="(value,name,index) in obj1" :key="value">{{name}}--{{value}}--{{index}}</li>
        </ol>
        <ol>
            <li v-for="num in num1" :key="num">{{num}}</li>
        </ol>
    </div>
</template>

<script>
export default {
    data(){  
        return{
            bool1:true,
            arr1:[{id:0,name:"张三"},{id:0,name:"李四"},{id:0,name:"王二麻子"}],
            obj1:{name:"张三",age:"18"},
            num1:3
        }
    },
    methods:{ 

    }
}
</script>