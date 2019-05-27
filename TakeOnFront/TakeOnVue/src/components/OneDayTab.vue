<template>
  <b-container fluid class="text-light text-center">
    <b-row
      v-for="question in text"
      class="text-center mb-3"
      :key="question.id"
      align-v="center">
      <b-col md="4" class="p-3 bg-info" >{{ question.question }}</b-col>
      <b-col md="8" class="p-3 bg-info"> {{ question.answer }}</b-col>
    </b-row>
  </b-container>
</template>

<script>
export default {
  name: 'OneDayTab',
  props: ['text'],
};
</script>

<style scoped>

</style>
