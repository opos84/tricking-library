<template>
  <v-row justify="center" align="center">
    <v-col cols="12" sm="8" md="6">
          <div v-if="tricks">
            <p v-for="t in tricks">
              {{t.name}}
            </p>
          </div>

          <div>
            <v-text-field label="Trick Name" v-model="trickName" />
            <v-btn @click="saveTrick">Save Tricks</v-btn>
          </div>


      <v-file-input @change="handleFile"></v-file-input>

<div>
  {{message}}
  <v-card>
    <v-btn @click="reset">Reset Nessage</v-btn>
    <v-btn @click="resetTricks">Reset Tricks</v-btn>
  </v-card>

</div>


    </v-col>
  </v-row>
</template>

<script>
import {mapState, mapActions, mapMutations} from 'vuex';
import Axios from "axios";

export default {
  data: () =>(
    {
      trickName: ""
    }
  ),
  computed: {
    ...mapState({
      message: state => state.message
    }),
    ...mapState('tricks',{
      tricks: state => state.tricks
    })
  },
  methods: {
    ...mapMutations([
      'reset'
    ]),
    ...mapMutations('tricks',{
      resetTricks: 'reset'
    }),
    ...mapActions('tricks', ['createTrick']),
    async saveTrick(){
      await this.createTrick({trick: {name:this.trickName}});
      this.trickName="";
    },
    async handleFile(file){
      if(!file){
        return;
      }
      console.log(file);

      const form = new FormData();
      form.append("video", file);

     const result = await Axios.post("http://localhost:5000/api/videos", form,
       );
     console.log("Result", result);
    }
  },
  // async fetch(){
  //   await this.$store.dispatch('fetchMessage');
  // }
  // asyncData(payload){
  // return Axios.get('http://localhost:5000/api/home')
  //     .then(({data}) => {
  //       return {
  //         message : data
  //       }
  //     })
  // }
}
</script>
