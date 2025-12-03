<!-- TODO: image gallery, adding images, creating collection, user data and stats -->
<template>
  <v-container id="root-container">
    
    <v-row justify="center">
      <v-col>
        <div id="profile-header" class="root-content-div">
          <!-- TODO: markdown bio editor
           https://github.com/DCsunset/vuetify-markdown-editor -->
          <h1>Hi I'm Greg</h1>
          <p>
            My user endpoint yields: {{ userInfo }} 
            <v-btn
              variant="text"
              icon="mdi-square-edit-outline"
              v-tooltip:="editBioToolip">
            </v-btn>
          </p>
        </div>
      </v-col>
      
    </v-row>
  </v-container>
</template>

<script lang="ts" setup>
  import axios from 'axios';

  const userInfo = ref("wait for it!");

  // fetch user info from backend
  let userName = "greg";
  axios.get(`/api/users/${userName}`)
    .then(response => {
      console.info(response.data)
      userInfo.value = response.data;
    })
    .catch(err => {
      console.error("err:", err);
    });

  // tooltip definition
  const editBioToolip = {
    text: "TODO: edit bio",
    persistent: false,
    openOnClick: true,
    openOnHover: false
  };
</script>