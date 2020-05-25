<template>
    <div>
        <base-span :test-str.sync="str1"></base-span>
        {{str1}}
    </div>
</template>

<script>
export default {
    props:{
    },
    data(){  
        return{
            str1:"ceshi",
        }
    },
    methods:{ 

    }
}
</script>