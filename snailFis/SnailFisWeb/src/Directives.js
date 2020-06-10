
export default{
    initMixins(Vue){
        Vue.directive('focus',{
            inserted:(el)=>{
                el.focus();
            }
        });
    }
}