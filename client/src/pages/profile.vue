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

    <v-row justify="center">
      <v-col>
        <div id="user-images" class="root-content-div">
          <h1>My images</h1>
           <div class="imageContainer">
            <v-img :src="images[page - 1].image" height="300px"></v-img>
            <p>
              {{ images[page - 1].title }}
            </p>
           </div>
          <v-pagination v-model="page" :length="pages" />
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
      // console.info(response.data)
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

  // image gallery
  // TODO: make an Image Template
  // TODO: fetch images from API
  const images = ref([
    {"image": "https://imgs.search.brave.com/4-q0ajKE9OOryXBk7IgDAwJztLfop-J9nmGApbbqIFA/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly90My5m/dGNkbi5uZXQvanBn/LzA1LzY0LzgxLzUy/LzM2MF9GXzU2NDgx/NTI0OV9MZXBTa0w2/NGIwd1JIN3NvajZO/N2RkcDlsQWJMcXNn/cC5qcGc",
      "title": "scatter"
    },
    {"image": "https://imgs.search.brave.com/3f7npJL7ntlUB4JqGvC0cm2H_u_lKiYQKnKKHmWqhwI/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly9wYW5k/YXMucHlkYXRhLm9y/Zy9kb2NzL19pbWFn/ZXMvcGFuZGFzLURh/dGFGcmFtZS1wbG90/LTIucG5n",
      "title": "chart"
    },
    {"image": "https://imgs.search.brave.com/o5O1kczzAI6f25nswrCkX7Pz7PlAt531FWANx3IdOWU/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly9wYW5k/YXMucHlkYXRhLm9y/Zy9kb2NzL19pbWFn/ZXMvcGFuZGFzLURh/dGFGcmFtZS1wbG90/LTEucG5n",
      "title": "bars"
    }
  ]);
  const page = ref(1);
  const pages = ref(images.value.length);

  // axios.get(`/api/users/${userName}/imageCount`)
  //   .then(response => {
  //     // console.info(response.data, response.data["imageCount"]);
  //     // pages.value = response.data["imageCount"];
  //   })
  //   .catch(err => {
  //     console.error("err:", err);
  //   });

</script>