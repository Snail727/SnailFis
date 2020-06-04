import Vue from 'vue'
import Router from 'vue-router'
import Menu from '@/components/Menu'
import HelloWorld from '@/components/HelloWorld'
import BtContent from '@/study/baseData/BtContent'
import AssContent from '@/study/component/AssContent'
import RouterContent from '@/study/routers/RouterContent'
import RouterChild from '@/study/routers/RouterChild'
import First from '@/study/routers/First'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      components: {default:HelloWorld,menu:Menu}
    },
    {
      path: '/BtContent',
      name: 'BtContent',
      component: BtContent
    },
    {
      path: '/AssContent',
      name: 'AssContent',
      component: AssContent
    },
    {
      path: '/RouterContent',
      name: 'RouterContent',
      component: RouterContent,
      children:[
        {path:'',component:First},
        {path:'RouterChild',component:RouterChild},
      ]
    }
  ]
})
