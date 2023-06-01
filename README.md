# TREU 2023

## Note: Due to formatting inconsistencies, these notebooks are meant to be run with Jupyter Notebook and not Google Colab. If you run them with Google Colab, the functionality will be the same, but the formatting may not. You may also need to figure out a way to load the required images in Colab. See "Installing Jupyter Notebook" for instructions on how to install and run Jupyter Notebook with Anaconda, Miniconda, or pip. Also, it may be useful for you to run these notebooks in a separate Python virtual environment. See "Virtual Environments" below for information on why virtual environments are useful, when you should/should not use them, and how to create/modify them. 

# Installing Anaconda: 
We recommend using Anaconda or Miniconda to manage your Python environments.
The setup for Anaconda and Miniconda will essentially be the same. Look here: https://www.educative.io/answers/anaconda-vs-miniconda to read about the differences between Anaconda and Miniconda

## Installation steps
1. Download Anaconda installer for your system at https://www.anaconda.com/, or Miniconda at https://docs.conda.io/en/latest/miniconda.html.
2. Begin Installation Process:
- Linux/Unix: Open the terminal and run: `bash Anaconda-latest-Linux-x86_64.sh` or `bash Miniconda3-latest-MacOSX-x86_64.sh` as appropriate. You may need to enable execution first by running `chmod +x Anaconda-latest-Linux-x86_64.sh` or `chmod +x Miniconda3-latest-MacOSX-x86_64.sh`.
- Windows: Run the .exe installer
- macOS: Open the .pkg file
3. Follow the prompts on the screen
4. Verify your installation of conda by opening the terminal (or Anaconda Prompt on Windows) and running `conda list`. A list of installed packages should appear if it is installed correctly. Note: For macOS and Linux.Unix, you can verify in the terminal, but you will have to close and open your terminal again for changes to take effect.
5. To create an environment, use the command: `conda create -n environment_name`, where `environment_name` is any name you want to name your environment. Then activate your environment with `conda activate environment_name`.
6. To install Jupyter, with your environment activated, use the command: `conda install jupyter`
7. To open Jupyter Notebook, use the command: `jupyter notebook`

# Installing Packages
**Python should already be installed in any environments you make with `conda`**. To install it manually, or to change the version, activate your environment and run `conda install python=version`, where `version` is the Python version you want to install, e.g. `3.10`. The material in this repository assumes you have at least version `3.10`.

Packages can be installed in your active envrionment using `conda install package` or `pip install package`. `pip` tends to have more packages available than `conda`.

For more information about conda environments, how to create and modify them, and what they can be useful for follow these links: 
 - https://conda.io/projects/conda/en/latest/user-guide/tasks/manage-environments.html
 - https://www.freecodecamp.org/news/why-you-need-python-environments-and-how-to-manage-them-with-conda-85f155f4353c/

# Using Jupyter Notebooks Remotely
You can use your local browser to view a Jupyter Notebook on any machine you have access to, such as your own GPU server.

On the remote server, with your environment activated,
```
jupyter notebook --no-browser --port=8080
```
This should give your some http links. Copy any one of those links. You can change the port number from 8080 if you prefer.

Then, on your local machine, e.g. your laptop, run
```
ssh -L 8080:localhost:8080 yourname@remoteserver
```
where `yourname` is your user name and `remoteserver` is the host name of the remote server.

Then, open a web browser and paste the link that you copied from before.

If you do not have a remote machine or GPU on your machine, you can use CHPC (super-computer of the University of Utah).

## Using Jupyter Notebooks on CHPC
1. Using your web-browser on the local machine open new window with the following address:
```
https://notchpeak.chpc.utah.edu:3300
```
Accept the connection and proceed to notchpeak.chpc.utah.edu

2. Log in using your Username (U-ID starting with letter 'u') and Password.

3. Now you are on CHPC. From the main page create a new terminal by clicking "+" button, select "xterm"

4. Download this repository to CHPC (if you haven't done it before)

```
[u1111111@notchpeak1:~]$ git clone https://github.com/damtharvey/reu2023.git
```

5. Once you are done, write command "myallocation", you should get something like this:

```
[u1111111@notchpeak1:~]$ myallocation
	You have a general allocation on kingspeak. Account: cs-reu, Partition: kingspeak
	You have a general allocation on kingspeak. Account: cs-reu, Partition: kingspeak-shared
	You have an owner allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-gpu-kp
	You have an owner allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-shared-gpu
	You have an owner allocation on kingspeak. Account: soc-kp, Partition: soc-kp
	You have an owner allocation on kingspeak. Account: soc-kp, Partition: soc-shared-kp
	You can use preemptable mode on kingspeak. Account: owner-guest, Partition: kingspeak-guest
	You can use preemptable GPU mode on kingspeak. Account: owner-gpu-guest, Partition: kingspeak-gpu-guest
	You have a GPU allocation on kingspeak. Account: soc-gpu-kp, Partition: soc-gpu-kp
	You have a GPU allocation on kingspeak. Account: kingspeak-gpu, Partition: kingspeak-gpu
	Your group cs-reu does not have a general allocation on notchpeak
	You can use preemptable mode on notchpeak. Account: cs-reu, Partition: notchpeak-freecycle
	You can use preemptable mode on notchpeak. Account: cs-reu, Partition: notchpeak-shared-freecycle
	You have a general allocation on notchpeak. Account: dtn, Partition: notchpeak-dtn
	You have a general allocation on notchpeak. Account: notchpeak-shared-short, Partition: notchpeak-shared-short
	You have an owner allocation on notchpeak. Account: soc-gpu-np, Partition: soc-gpu-np
	You have an owner allocation on notchpeak. Account: soc-gpu-np, Partition: soc-shared-gpu
	You have an owner allocation on notchpeak. Account: coe-np, Partition: coestudent-np
	You have an owner allocation on notchpeak. Account: coe-np, Partition: coestudent-shared-np
	You can use preemptable GPU mode on notchpeak. Account: owner-gpu-guest, Partition: notchpeak-gpu-guest
	You can use preemptable mode on notchpeak. Account: owner-guest, Partition: notchpeak-guest
	You have a GPU allocation on notchpeak. Account: soc-gpu-np, Partition: soc-gpu-np
	You have a GPU allocation on notchpeak. Account: notchpeak-gpu, Partition: notchpeak-gpu
	You have a general allocation on lonepeak. Account: cs-reu, Partition: lonepeak
	You have a general allocation on lonepeak. Account: cs-reu, Partition: lonepeak-shared
	You can use preemptable mode on lonepeak. Account: owner-guest, Partition: lonepeak-guest
	You have a GPU allocation on lonepeak. Account: lonepeak-gpu, Partition: lonepeak-gpu
```
6. Now, select an account and partition with GPU, here it can be ```soc-gpu-np:soc-gpu-np```, ```notchpeak-gpu:notchpeak-gpu``` (containts ```gpu```). Also pay attention to an allocation for this account (notchpeak/lonepeak...)

7. Let's connect to the chosen account to access gpu resources. Here is an example for allocation:notchpeak, account:soc-gpu-np, partition:soc-gpu-np, allocation for 1 hour(-t), 1 physical compute node (--nodes) and 1 logical process (--ntasks)

```
[u1111111@notchpeak1:~]$ srun -M notchpeak --account=soc-gpu-np --partition=soc-gpu-np --nodes=1
--ntasks=1 --gres=gpu -t 1:00:00 --pty bash
```

8. After success, we are on the GPU-allocation from where we can launch Jupyter Notebook. Use the following commands to launch Jupyter Notebook:
```
[u1111111@notch367:~]$ module load python3
[u1111111@notch367:~]$ jupyter notebook --browser=/usr/bin/google-chrome
```
