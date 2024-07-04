---
title: GitHub Actions Request
# lead:
tags:
  - programming
  - github
  - github-actions
author: alex-hedley
# description:
published: 2021-12-24
# image:
# imageattribution:
---

The [actions/github-script](https://github.com/actions/github-script) has an option to send a request, that is already authenticated with the GitHub API.

`const diff_url = context.payload.pull_request.diff_url`
`const result = await github.request(diff_url)`

- [Download data from a URL](https://github.com/actions/github-script#download-data-from-a-url)
